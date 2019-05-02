using System;
using System.Text;


namespace Jogo18Ghosts
{
    class GamePlay
    {
        private static void Main(string[] args)
        {
            //Asks Player Names
            Console.WriteLine("Tell me your names Player 1, Player 2.");

            var player1 = new PlayerYellow()
            {
                Name = Console.ReadLine()

            };

            var player2 = new PlayerBlue()
            {
                Name = Console.ReadLine()
            };



            //Prints who Won and who can interact with who 
            var winner = new Battle(player1, player2).PlayMatchUp();

            if (winner == null)
            {
                Console.WriteLine("You cannot fight him.");
            }
            else
            {
                Console.WriteLine("The Winner of this battle is {0}", winner.Name);
            }

            Console.ReadKey();

            Console.OutputEncoding = Encoding.UTF8;
            GameBoard board;

            board = new GameBoard();

            board.Board();





        }

    }
}
