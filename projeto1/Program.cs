using System;

namespace Jogo18Ghosts
{
    class Program
    {
        static void Main(string[] args)
        {
            string userMoveChoice = Console.ReadLine();
            string userMoveChoiceLowCase = userMoveChoice.ToLower();
            
            //string moveUp, moveDown, moveLeft, moveRight;

            if (userMoveChoiceLowCase == "up")
            {
                Console.WriteLine("HEHHEE");
              
            }
            else
            {
                Console.WriteLine("HAHAHAHAHAH LOSER");
            }

            Console.ReadKey();

        }
    }
}
