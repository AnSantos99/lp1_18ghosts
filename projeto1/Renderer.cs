using System;
using System.Text;

namespace Jogo18Ghosts
{
    internal class Renderer
    {
        public void Render(GameBoard board)
        {
            char[,] symbols = new char[5, 5];

            Console.OutputEncoding = Encoding.UTF8;

            int col = 5, row = 5;

            for (int i = 0; i < row; i++)
            {

                for (int j = 0; j < col; j++)
                {
                    symbols[i, j] = SymbolFor(board.GetState(new Position(i, j)));

                }
              
            }

            Console.WriteLine("  __[A]_|_[B]_|_[C]_|_[D]_|_[E]__");

            for (int o = 0; o < row; o++)
            {
                Console.WriteLine("  |     |     |     |     |     |");
                Console.Write($"[{o}]");
                for (int w = 0; w < col; w++)
                {
                    Console.Write("  " + symbols[o, w] + "  |");
                }

               // Console.Write("|");
                Console.WriteLine();
                Console.WriteLine("  |__ __|__ __|__ __|__ __|__ __|");
            }

            Console.WriteLine("  |                             |");
            Console.WriteLine("  |_____________________________|");

        }

        private char SymbolFor(State state)
        {
            switch(state)
            {
                case State.P1: return '\u14C6';
                case State.P2: return '\u07F7';
                default: return ' ';

            }
        }

        public void RenderResults(State winner)
        {
            switch (winner)
            {
                case State.P1:
                case State.P2:
                    Console.WriteLine(SymbolFor(winner) + "wins!");
                    break;

                case State.Undecided:
                    Console.WriteLine("Draw!");
                    break;

            }
        }
    }
}