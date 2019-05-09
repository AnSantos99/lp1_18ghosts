using System;
using System.Text;

namespace Jogo18Ghosts
{
    /// <summary>
    /// this class serves as the main looping system for the game, where
    /// the rendering function is called to draw on the board until the winning
    /// condition is met by one of the players
    /// </summary>
    internal class GameLoop
    {
        //calling other classes to create a new board and check who the current
        //player is on this turn
        internal static GameBoard board;
        internal static Player currentPlayer;

        /// <summary>
        /// this method has no return and its purpose is to run the game upon
        /// being called inside the Program.cs
        /// </summary>
        internal static void Run()
        {

            //allowing the use of UNICODE on the console
            Console.OutputEncoding = Encoding.UTF8;

            //initialising the two players for the loop
            Player player1;
            Player player2;

            //initialising the game board variable from the GameBoard class
            board = new GameBoard();

            //declaring the variables
            player1 = new Player('1');
            player2 = new Player('2');

            //for loop for adding the 9 ghosts to each player's list, 3 of a
            //different colour each time
            for (int i = 0; i<3; i++)
            {
                //add the 1st player's three colours of ghosts
                player1.ghosts.Add(new YellowGhost(player1));
                player1.ghosts.Add(new BlueGhost(player1));
                player1.ghosts.Add(new RedGhost(player1));

                //add the 2nd player's three colours of ghosts
                player2.ghosts.Add(new YellowGhost(player2));
                player2.ghosts.Add(new BlueGhost(player2));
                player2.ghosts.Add(new RedGhost(player2));
            }

            //set the current player to player two so we can switch to 1 later
            currentPlayer = player2;

            //in case of incorrect input from the user
            bool error; 
            
            error = false;

            //this cycle is for placing the ghosts on the board before the game
            for (int i = 0; i < 18; i++)
            {
                //check player number in order to switch
                if (i != 2 && !error)
                {
                    //switch player for the alternating turns placing ghosts
                    if (currentPlayer == player1)
                        currentPlayer = player2;
                    else
                        currentPlayer = player1;

                }
                //set error to false for next loop
                error = false;
                
                //add ghost to current player
                Ghosts ghost = currentPlayer.ghosts[i / 2];
                
                //clear console for cleaner outputs
                Console.Clear();


                Console.WriteLine("Escape the Castle!!!");
                //call the renderer function to draw the board on the console
                board.Render();

                //tell the player how to place the ghosts
                Console.WriteLine("Order of Placing:");
                Console.WriteLine(" First Turn:");
               
                Console.WriteLine("  Player1 Yellow Ghost,  Player2 Yellow Ghost" +
                    ",  Player2 Blue Ghost\n");
       
                Console.WriteLine(" Remaining Turns:");
                Console.WriteLine("  Player1 Blue Ghost,  Player2 Red Ghost" +
                    ",  Player1 Red Ghost, repeat");

                Console.WriteLine((ghost.player == player1 ? "player1" 
                    : "player2") + ": Place your ghost");

                //get the position chosen by the player and set it on the board
                Position pos = Player.GetPosition(board);
                
                //set error to true if the chosen position isn't valid
                if (board.pieces[pos.Row, pos.Col] is Ghosts || 
                    board.pieces[pos.Row, pos.Col].color != ghost.color ||
                    board.pieces[pos.Row, pos.Col] is Portals)
                {
                    i--;
                    error = true;
                    continue;
                }
                
                //place the ghosts and their given positions on the board
                board.SetGhost(ghost, pos);

            }

            //set currentPlayer back to 2 for usage in the do while game cycle
            currentPlayer = player2;

            //initializing the game cycle until a player has won or quit the game
            do
            {
                //conditions to switch players
                if (currentPlayer == player1)
                    currentPlayer = player2;
                else
                    currentPlayer = player1;

                //clear the previous board console to render the new state
                Console.Clear();
                
                //let user know who's currently playing
                Console.WriteLine(currentPlayer == player1 ? "player1" : "player2");

                //render the board on the console
                board.Render();

                //update the board if a ghost is moved from a corridor
                Update();
            }

            //run until a player has won the game
            while (!player1.Won() && !player2.Won());
            
            // check what player has won the game and print the result
            if (player1.Won())
                Console.WriteLine("Congratulations!!! Player 1 is free!!");
            else if (player2.Won())
                Console.WriteLine("Congratulations!!! Player 2 is free!!");

            //reads player's input
            Console.ReadKey();

        }

        /// <summary>
        /// this method gets a ghost, its position and a new position to where
        /// the player wants to move it, and updates the portals if there's
        /// been a battle between ghosts. it doesn't return anything.
        /// </summary>
        /// <param name="piece"> the current ghost type</param>
        /// <param name="newPos"> the position to which it's been moved</param>
        /// <param name="oldPos"> the position it was originally in</param>

        private static void MovePiece(BoardPiece piece, Position newPos, Position oldPos)
        {
            //
            board.pieces[newPos.Row, newPos.Col] = GameBoard.GetBoardSettings(newPos);
            board.pieces[oldPos.Row, oldPos.Col] = piece;

            board.UpdatePortal(piece.color);
        }

        /// <summary>
        /// this method returns nothing. it's purpose is to update the board
        /// </summary>
        private static void Update()
        {
            if (board.CountdungeonGhostsForPlayer(currentPlayer) > 0)
            {
                Console.WriteLine("Quer mover ou ressuscitar um fantasma? (R/F)");
                if (Console.ReadLine().ToUpper() == "R")
                {
                    Console.WriteLine("Que fantasma que ressuscitar?");
                    Ghosts ghost = board.GetDungeonGhost(Console.ReadLine());

                    if (ghost != null)
                    {
                        BoardPiece fPiece = null;
                        Position fPos = null;
                        do
                        {
                            Console.WriteLine("Que posição quer por o fantasma?");
                            fPos = Player.GetPosition(board);
                            fPiece = board.GetPiece(fPos);
                        }
                        while (fPiece is Ghosts || fPiece is Portals);

                        board.pieces[fPos.Row, fPos.Col] = ghost;
                        board.dungeonGhosts.Remove(ghost);

                        board.UpdatePortal(ghost.color);
                    }

                    return;
                }
            }
           
            //set the default pieces to null to use and replace them later
            BoardPiece piece = null;

            //get a variable of Position type to simplify use
            Position pos;

            //to ask the player which ghost they want to move and getting it
            do
            {
                Console.WriteLine("Que fantasma quer mover?");
                pos = Player.GetPosition(board);
                piece = board.GetPiece(pos);
            }
            //do while piece belongs to the player
            while (!(piece is Ghosts ghost && ghost.player == currentPlayer));

            //auxiliary piece to check types of corridors that aren't ghosts
            BoardPiece auxPiece;
            Position auxPosition; 
            bool isValidPosition;
            
            //declare the new piece's values as null to use for different types
            auxPiece = null;
            auxPosition = null;
            isValidPosition = false;

            //ask player where to move the piece and check for it's validity
            do
            {
                Console.WriteLine("Where do you want to move it to?");

                auxPosition = Player.GetPosition(board);
                auxPiece = board.GetPiece(auxPosition);

                uint abs1 = (uint)Math.Abs(auxPosition.Row - pos.Row);
                uint abs2 = (uint)Math.Abs(auxPosition.Col - pos.Col);

                isValidPosition = (abs1 <= 1 && abs2 <= 1 && abs1 + abs2 <= 1);
            }
            while (auxPiece is Portals || !isValidPosition);

            if (auxPiece is Ghosts ghosts)
            {
                if (((Ghosts)piece).checkWinner(ghosts))
                {
                    MovePiece(piece, pos, auxPosition);
                    board.OnPieceLost(auxPiece);
                }
                else
                {
                    board.pieces[pos.Row, pos.Col] = GameBoard.GetBoardSettings(pos);
                    board.OnPieceLost(piece);
                }
            }
            else if (auxPiece is Mirror mirror)
            {
                BoardPiece auxMirror = null;
                Position mirrorPos = null;

                uint mirrorCount = board.CountMirrors();
                if (mirrorCount > 1)
                {
                    do
                    {
                        Console.WriteLine("Para que espelho que ir?");
                        mirrorPos = Player.GetPosition(board);
                        auxMirror = board.GetPiece(mirrorPos);

                    } while (!(auxMirror is Mirror));

                    board.pieces[pos.Row, pos.Col] = GameBoard.GetBoardSettings(pos);
                    board.pieces[mirrorPos.Row, mirrorPos.Col] = piece;

                    board.UpdatePortal(piece.color);
                }
                else
                    MovePiece(piece, pos, auxPosition);
            }
            else
                MovePiece(piece, pos, auxPosition);
        }
    }
}