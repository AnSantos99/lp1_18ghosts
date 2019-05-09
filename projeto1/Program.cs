using System;
using System.Text;

namespace Jogo18Ghosts
{
    /// <summary>
    /// this class is the main Program file, it will call the gameloop to begin
    /// running the game, placing pieces and rendering on the console 
    /// </summary>
    internal class Program
    {
        private static void Main(string[] args)
        {
            // allowing the use of UNICODE on the console
            Console.OutputEncoding = Encoding.UTF8;

            // call the GameLoop class to run the game
            GameLoop.Run();

        }
    }
}