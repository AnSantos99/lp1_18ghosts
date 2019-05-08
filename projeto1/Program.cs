using System;
using System.Text;

namespace Jogo18Ghosts
{
    internal class Program
    {
        private enum GameState
        {
            moving
        }

        static GameBoard board;
        static GameState gameState = GameState.moving;
        static PlayerFix currentPlayer;

        private static void Main(string[] args)
        {
            //allowing the use of UNICODE on the console
            Console.OutputEncoding = Encoding.UTF8;

            //initialising variables related to each class needed

            WinChecker winChecker;

            PlayerFix player1;
            PlayerFix player2;


            //declaring the variables
            board = new GameBoard();
            winChecker = new WinChecker();

            player1 = new PlayerFix('1');
            player2 = new PlayerFix('2');

            player1.ghosts.Add(new YellowGhost(player1));
            player1.ghosts.Add(new YellowGhost(player1));
            player1.ghosts.Add(new YellowGhost(player1));
            player1.ghosts.Add(new BlueGhost(player1));
            player1.ghosts.Add(new BlueGhost(player1));
            player1.ghosts.Add(new BlueGhost(player1));
            player1.ghosts.Add(new RedGhost(player1));
            player1.ghosts.Add(new RedGhost(player1));
            player1.ghosts.Add(new RedGhost(player1));

            player2.ghosts.Add(new YellowGhost(player2));
            player2.ghosts.Add(new YellowGhost(player2));
            player2.ghosts.Add(new YellowGhost(player2));
            player2.ghosts.Add(new BlueGhost(player2));
            player2.ghosts.Add(new BlueGhost(player2));
            player2.ghosts.Add(new BlueGhost(player2));
            player2.ghosts.Add(new RedGhost(player2));
            player2.ghosts.Add(new RedGhost(player2));
            player2.ghosts.Add(new RedGhost(player2));

            currentPlayer = player2;
            bool error = false;

            for (int i = 0; i < 18; i++)
            {
                if (i != 2 && !error)
                {
                    if (currentPlayer == player1)
                        currentPlayer = player2;
                    else
                        currentPlayer = player1;

                }
                error = false;
                Ghosts ghost = currentPlayer.ghosts[i / 2];

                Console.Clear();

                board.render();
                Console.WriteLine((ghost.player == player1 ? "player1" : "player2") + ": Place your ghost");
                Position pos = PlayerFix.GetPosition(board);
                if (board.pieces[pos.Row, pos.Col] is Ghosts || board.pieces[pos.Row, pos.Col].color != ghost.color ||
                    board.pieces[pos.Row, pos.Col] is Portals)
                {
                    i--;
                    error = true;
                    continue;

                }

                board.SetGhost(ghost, pos);

            }

            currentPlayer = player2;
            //initializing the game cycle until a player has won or quit the game
            do
            {

                if (currentPlayer == player1)
                    currentPlayer = player2;
                else
                    currentPlayer = player1;

                Console.Clear();
                Console.WriteLine(currentPlayer == player1 ? "player1" : "player2");
                board.render();

                Update();


            }

            //run while noone has won nor tied
            while ((!winChecker.IsDraw(board) && winChecker.Check(board) == State.Undecided));

            board.render();
        }

        private static void Update()
        {
            switch (gameState)
            {
                case GameState.moving:
                    BoardPiece piece = null;
                    Position pos;
                    do
                    {
                        Console.WriteLine("Que fantasma quer mover?");
                        pos = PlayerFix.GetPosition(board);
                        piece = board.GetPiece(pos);
                    }
                    while (!(piece is Ghosts ghost && ghost.player == currentPlayer));

                    BoardPiece auxPiece = null;
                    Position auxPosition = null;
                    bool isValidPosition = false;
                    do
                    {
                        Console.WriteLine("Where do you want to move it to?");

                        auxPosition = PlayerFix.GetPosition(board);
                        auxPiece = board.GetPiece(auxPosition);

                        isValidPosition = (Math.Abs(auxPosition.Row - pos.Row) <= 1 && Math.Abs(auxPosition.Col - pos.Col) <= 1);
                    }
                    while (auxPiece is Portals || !isValidPosition);

                    if (auxPiece is Ghosts ghosts)
                    {
                        if (((Ghosts)piece).checkWinner(ghosts))
                        {
                            board.pieces[pos.Row, pos.Col] = GameBoard.GetBoardSettings(pos);
                            board.pieces[auxPosition.Row, auxPosition.Col] = piece;

                        }

                        else
                        {
                            board.pieces[pos.Row, pos.Col] = GameBoard.GetBoardSettings(pos);
                        }
                    }





                    break;
            }
        }
    }
}
