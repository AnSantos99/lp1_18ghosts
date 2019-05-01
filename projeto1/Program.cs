using System;
using System.Text;


namespace Jogo18Ghosts
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            GameBoard board;

            board = new GameBoard();

            board.Board();


        }
    }
}
