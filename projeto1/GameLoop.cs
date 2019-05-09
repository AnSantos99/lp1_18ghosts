using System;
using System.Text;

namespace Jogo18Ghosts
{
    internal class GameLoop
    {

        internal static GameBoard board;
        internal static Player currentPlayer;

        internal static void Run()
        {

            //allowing the use of UNICODE on the console
            Console.OutputEncoding = Encoding.UTF8;

            //initialising variables related to each class needed
            Player player1;
            Player player2;

            //declaring the variables
            board = new GameBoard();


            player1 = new Player('1');
            player2 = new Player('2');

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

                //Console.Clear();

                board.render();
                Console.WriteLine((ghost.player == player1 ? "player1" : "player2") + ": Place your ghost");
                Position pos = Player.GetPosition(board);
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
            while (!player1.Won() && !player2.Won());

            if (player1.Won())
                Console.WriteLine("Player 1 Has WON!!");
            else if (player2.Won())
                Console.WriteLine("Player 2 Has WON!!");

            Console.ReadKey();

        }

        private static void MovePiece(BoardPiece piece, Position newPos, Position oldPos)
        {
            board.pieces[newPos.Row, newPos.Col] = GameBoard.GetBoardSettings(newPos);
            board.pieces[oldPos.Row, oldPos.Col] = piece;

            board.UpdatePortal(piece.color);
        }

        private static void Update()
        {
            if (board.CountLostSoulsForPlayer(currentPlayer) > 0)
            {
                Console.WriteLine("Quer mover ou ressuscitar um fantasma? (R/F)");
                if (Console.ReadLine().ToUpper() == "R")
                {
                    Console.WriteLine("Que fantasma que ressuscitar?");
                    Ghosts ghost = board.GetLostSoul(Console.ReadLine());

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
                        board.lostSouls.Remove(ghost);

                        board.UpdatePortal(ghost.color);
                    }

                    return;
                }
            }

            BoardPiece piece = null;
            Position pos;
            do
            {
                Console.WriteLine("Que fantasma quer mover?");
                pos = Player.GetPosition(board);
                piece = board.GetPiece(pos);
            }
            while (!(piece is Ghosts ghost && ghost.player == currentPlayer));

            BoardPiece auxPiece = null;
            Position auxPosition = null;
            bool isValidPosition = false;
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