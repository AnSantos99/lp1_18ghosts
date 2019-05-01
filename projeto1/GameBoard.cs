using System;
using System.Collections.Generic;
using System.Text;

namespace Jogo18Ghosts
{
    class GameBoard
    {
        public void Board()
        {
            Console.OutputEncoding = Encoding.UTF8;

            char ghost = '\u07F7';
            char corridor = '\u20DE';
            /*
            char portalDown = ;
            char portalLeft = ;
            char portalRight = ;
            char mirror = '\u20DE';
            char portalUp = '\u20DD';
            */

            string[,] board = new string[5, 5];

            int col = board.GetLength(1);
            int row = board.GetLength(0);

            Console.WriteLine("__[A]_|_[B]_|_[C]_|_[D]_|_[E]__");

            //For loop to print the inside
            for (int i = 0; i < row; i++)
            {
                Console.WriteLine("|     |     |     |     |     |");
                Console.Write($"[{i}]");
                for (int j = 0; j < col; j++)
                {

                    if (i == 0)
                    {
                        if (j == 0 || j == 3)
                        {
                            board[i, j] = "b";
                            Console.Write(board[i, j] + "   ");                
                        }

                        else if (j == 1 || j == 4)
                        {
                            board[i, j] = "r";    
                            Console.Write("  " + board[i, j] + "  ");
                        }

                        else
                        {
                            board[i, j] = "rp";
                            Console.Write("  " + board[i, j] + "     ");
                        }
                    }
                    if (i == 1)
                    {
                        if (j == 0 || j == 1 || j == 2)
                        {
                            board[i, j] = "y"; 
                            Console.Write(board[i, j] + "     ");
                        }

                        else
                        {
                            board[i, j] = "M";
                            Console.Write(" " + board[i, j] + "   ");
                        }
                    }
                    if (i == 2)
                    {
                        if (j == 0 || j == 2)
                        {
                            board[i, j] = "r";
                            Console.Write(board[i, j] + "  ");
                        }

                        else if (j == 1 || j == 3)
                        {
                            board[i, j] = "b";
                            Console.Write("   " + board[i, j] + "     ");
                        }

                        else
                        {
                            board[i, j] = "yp";
                            Console.Write(board[i, j] + " ");
                        }
                    }
                    if (i == 3)
                    {
                        if (j == 0)
                        {
                            board[i, j] = "b";
                            Console.Write(board[i, j] + "  ");
                        }

                        else if (j == 2)
                        {
                            board[i, j] = "y";
                            Console.Write("   " + board[i, j] + "  ");
                        }

                        else if (j == 4)
                        {
                            board[i, j] = "r";
                            Console.Write("   " + board[i, j] + "  ");
                        }

                        else
                        {
                            board[i, j] = "M";
                            Console.Write("   " + board[i, j] + "  ");
                        }
                    }
                    if (i == 4)
                    {
                        if (j == 0 || j == 4)
                        {
                            board[i, j] ="y";
                            Console.Write(board[i, j] + "  ");
                        }

                        else if (j == 3)
                        {
                            board[i, j] = "b";
                            Console.Write("   " + board[i, j] + "     ");
                        }

                        else if (j == 2)
                        {
                            board[i, j] = "r";
                            Console.Write("   " + board[i, j] + "  ");
                        }

                        else
                        {
                            board[i, j] = "bp";
                            Console.Write("   " + board[i, j] + " ");
                        }
                    }

                }
                Console.Write("|");
                Console.WriteLine();
                Console.WriteLine("|__ __|__ __|__ __|__ __|__ __|");
            }
            Console.WriteLine("|                             |");
            Console.WriteLine("|_____________________________|");
        }
    }
}