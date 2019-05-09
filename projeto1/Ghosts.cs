using System;
using System.Collections.Generic;
using System.Text;

namespace Jogo18Ghosts
{

    /// <summary>
    /// 
    /// </summary>
    abstract public class Ghosts : BoardPiece
    {

        public PlayerFix player;


        public Ghosts(PlayerFix player)
        {

            this.player = player;
        }

        abstract public bool checkWinner(Ghosts ghost);

    }

    /// <summary>
    /// this class obtains the player and their current ghost's colour, rendering
    /// it as the prefix (the current player number) and the respective colour properly
    /// it then has a method to check which ghost it's facing against on the next
    /// position to see which one wins
    /// </summary>
    public class YellowGhost : Ghosts
    {
        public YellowGhost(PlayerFix player) : base(player) { color = ConsoleColor.Yellow; }

        public override void Render(bool spaces = true)
        {
            ConsoleColor auxColor = Console.ForegroundColor;

            Console.ForegroundColor = ConsoleColor.Yellow;

            if (spaces)
                Console.Write(" Y" + player.prefix + "   ");
            else
                Console.Write("Y" + player.prefix);

            Console.ForegroundColor = auxColor;
        }

        public override bool checkWinner(Ghosts ghost)
        {
            return ghost.color == ConsoleColor.Red;
        }
    }

    public class RedGhost : Ghosts
    {
        public RedGhost(PlayerFix player) : base(player) { color = ConsoleColor.Red; }

        public override void Render(bool spaces = true)
        {
            ConsoleColor auxColor = Console.ForegroundColor;

            Console.ForegroundColor = ConsoleColor.Red;

            if (spaces)
                Console.Write(" R" + player.prefix + "   ");
            else
                Console.Write("R" + player.prefix);

            Console.ForegroundColor = auxColor;
        }
        public override bool checkWinner(Ghosts ghost)
        {
            return ghost.color == ConsoleColor.Blue;
        }
    }




    public class BlueGhost : Ghosts
    {
        public BlueGhost(PlayerFix player) : base(player) { color = ConsoleColor.Blue; }

        public override void Render(bool spaces = true)
        {
            ConsoleColor auxColor = Console.ForegroundColor;

            Console.ForegroundColor = ConsoleColor.Blue;

            if (spaces)
                Console.Write(" B" + player.prefix + "   ");
            else
                Console.Write("B" + player.prefix);

            Console.ForegroundColor = auxColor;
        }
        public override bool checkWinner(Ghosts ghost)
        {
            return ghost.color == ConsoleColor.Yellow;
        }
    }

}
