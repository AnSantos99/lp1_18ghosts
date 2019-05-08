using System;
using System.Collections.Generic;
using System.Text;

namespace Jogo18Ghosts
{
<<<<<<< HEAD
    public class GameBoard
    {
        private State[,] state;
        public State NextTurn { get; private set; }
        private uint width = 5, height = 5;
        public BoardPiece[,] pieces;
=======
    internal class GameBoard
    {
        private State[,] state;
        public State NextTurn { get; private set; }
>>>>>>> upstream/master

        public GameBoard()
        {
            state = new State[5, 5];
<<<<<<< HEAD

            pieces = new BoardPiece[width, height];
            pieces[0, 0] = new BoardPiece("b", ConsoleColor.Blue);
            pieces[0, 1] = new BoardPiece("r", ConsoleColor.Red);
            pieces[0, 2] = new RedPortal(Portals.Direction.up);
            pieces[0, 3] = new BoardPiece("b", ConsoleColor.Blue);
            pieces[0, 4] = new BoardPiece("r", ConsoleColor.Red);

            pieces[1, 0] = new BoardPiece("y", ConsoleColor.Yellow);
            pieces[1, 1] = new BoardPiece("M", ConsoleColor.White);
            pieces[1, 2] = new BoardPiece("y", ConsoleColor.Yellow);
            pieces[1, 3] = new BoardPiece("M", ConsoleColor.White);
            pieces[1, 4] = new BoardPiece("y", ConsoleColor.Yellow);

            pieces[2, 0] = new BoardPiece("r", ConsoleColor.Red);
            pieces[2, 1] = new BoardPiece("b", ConsoleColor.Blue);
            pieces[2, 2] = new BoardPiece("r", ConsoleColor.Red);
            pieces[2, 3] = new BoardPiece("b", ConsoleColor.Blue);
            pieces[2, 4] = new YellowPortal(Portals.Direction.right);

            pieces[3, 0] = new BoardPiece("b", ConsoleColor.Blue);
            pieces[3, 1] = new BoardPiece("M", ConsoleColor.White);
            pieces[3, 2] = new BoardPiece("y", ConsoleColor.Yellow);
            pieces[3, 3] = new BoardPiece("M", ConsoleColor.White);
            pieces[3, 4] = new BoardPiece("r", ConsoleColor.Red);

            pieces[4, 0] = new BoardPiece("y", ConsoleColor.Yellow);
            pieces[4, 1] = new BoardPiece("r", ConsoleColor.Red);
            pieces[4, 2] = new BluePortal(Portals.Direction.down);
            pieces[4, 3] = new BoardPiece("b", ConsoleColor.Blue);
            pieces[4, 4] = new BoardPiece("y", ConsoleColor.Yellow);




            NextTurn = State.P1;
        }
        
        public static BoardPiece GetBoardSettings(Position pos)
        {
            switch(pos.Row)
            {
                case 0:
                    switch(pos.Col)
                    {
                        case 0:
                            return new BoardPiece("b", ConsoleColor.Blue);
                        case 1:
                            return new BoardPiece("r", ConsoleColor.Red);
                        case 2:
                            return new RedPortal(Portals.Direction.up);
                        case 3:
                            return new BoardPiece("b", ConsoleColor.Blue);
                        case 4:
                            return new BoardPiece("r", ConsoleColor.Red);
                    }
                    break;
                case 1:
                    switch (pos.Col)
                    {
                        case 0:
                            return new BoardPiece("y", ConsoleColor.Yellow);
                        case 1:
                            return new BoardPiece("M", ConsoleColor.White);
                        case 2:
                            return new BoardPiece("y", ConsoleColor.Yellow);
                        case 3:
                            return new BoardPiece("M", ConsoleColor.White);
                        case 4:
                            return new BoardPiece("y", ConsoleColor.Yellow);
                    }
                    break;
                case 2:
                    switch (pos.Col)
                    {
                        case 0:
                            return new BoardPiece("r", ConsoleColor.Red);
                        case 1:
                            return new BoardPiece("b", ConsoleColor.Blue);
                        case 2:
                            return new BoardPiece("r", ConsoleColor.Red);
                        case 3:
                            return new BoardPiece("b", ConsoleColor.Blue);
                        case 4:
                            return new YellowPortal(Portals.Direction.right);
                    }
                    break;
                case 3:
                    switch (pos.Col)
                    {
                        case 0:
                            return new BoardPiece("b", ConsoleColor.Blue);
                        case 1:
                            return new BoardPiece("M", ConsoleColor.White);
                        case 2:
                            return new BoardPiece("y", ConsoleColor.Yellow);
                        case 3:
                            return new BoardPiece("M", ConsoleColor.White);
                        case 4:
                            return new BoardPiece("r", ConsoleColor.Red);
                    }
                    break;
                case 4:
                    switch (pos.Col)
                    {
                        case 0:
                            return new BoardPiece("y", ConsoleColor.Yellow);
                        case 1:
                            return new BoardPiece("r", ConsoleColor.Red);
                        case 2:
                            return new BluePortal(Portals.Direction.down);
                        case 3:
                            return new BoardPiece("b", ConsoleColor.Blue);
                        case 4:
                            return new BoardPiece("y", ConsoleColor.Yellow);
                    }
                    break;
            }
            return null;
        }
=======
            NextTurn = State.P1;
        }
>>>>>>> upstream/master

        public State GetState(Position position)
        {
            return state[position.Row, position.Col];
        }
<<<<<<< HEAD

        public void SetGhost(Ghosts ghost, Position pos)
        {
            ghost.pos = pos;
            pieces[pos.Row, pos.Col] = ghost;
        }

        public bool SetState(Position position, State newState)
        {
            if (newState != NextTurn) return false;
            //if (state[position.Row, position.Col] != State.Undecided) return false;
            state[position.Row, position.Col] = newState;
            SwitchNextTurn();
            return true;
        }

        public BoardPiece GetPiece(Position pos)
        {
            return pieces[pos.Row, pos.Col];
               
        }

        public void render()
        {
            Console.WriteLine("  __[A]_|_[B]_|_[C]_|_[D]_|_[E]__");

            for (uint y = 0; y<height; y++)
            {
                Console.WriteLine("  |     |     |     |     |     |");
                Console.Write($"[{y + 1}] ");
                for (uint x = 0; x<width; x++)
                {
                    if (pieces[y, x] != null)
                    {
                        pieces[y, x].Render();
                    }
                }

                Console.WriteLine();
                Console.WriteLine("  |__ __|__ __|__ __|__ __|__ __|");
            }


            Console.WriteLine("  |                             |");
            Console.WriteLine("  |                             |");
            Console.WriteLine("  |_____________________________|");
        }

=======

        public bool SetState(Position position, State newState)
        {
            if (newState != NextTurn) return false;
            if (state[position.Row, position.Col] != State.Undecided) return false;

            state[position.Row, position.Col] = newState;
            SwitchNextTurn();
            return true;
        }

>>>>>>> upstream/master
        private void SwitchNextTurn()
        {
            if (NextTurn == State.P1) NextTurn = State.P2;
            else NextTurn = State.P1;
        }
     }
 }