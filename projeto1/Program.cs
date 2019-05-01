using System;

namespace Jogo18Ghosts
{
    class Program
    {
        static void Main(string[] args)
        {
            
            //Console.WriteLine("Where do you wanna go?");

            Player playerActions = new Player();
  
            Console.WriteLine("Do you want to use a normal move or do you" +
                "wanna use the mirror chambers?");

            string userInput = Console.ReadLine();

            playerActions.Act1GhostMovement(userInput);
            
            


            //int mirrorUpLeft, mirrorUpRight, mirrorDownLeft, mirrorDownRight;

            //int [,] testBoard = new int [5,5];

           



            Console.ReadKey();

        }
    }
}
