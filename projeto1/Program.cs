using System;
using System.Text;

namespace Jogo18Ghosts
{
    internal class Program
    {
        static GameBoard board;
        static PlayerFix currentPlayer;

        private static void Main(string[] args)
        {
            //allowing the use of UNICODE on the console
            Console.OutputEncoding = Encoding.UTF8;
            GameLoop.Run();

        }
    }
}