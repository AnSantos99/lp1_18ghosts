using System;
using System.Text;

namespace Jogo18Ghosts
{
    /// <summary>
    /// 
    /// </summary>
    abstract internal class Ghosts : BoardPiece 
    {

        internal Player player;


        internal Ghosts(Player player)
        {

            this.player = player;
        }

        abstract internal bool checkWinner(Ghosts ghost);

    }

    /// <summary>
    /// this class obtains the player and their current ghost's colour, rendering
    /// it as the prefix (the current player number) and the respective colour properly
    /// it then has a method to check which ghost it's facing against on the next
    /// position to see which one wins
    /// </summary>
    internal class YellowGhost : Ghosts
    {
        internal YellowGhost(Player player) : base(player) { color = ConsoleColor.Yellow; }

        internal override void Render(bool spaces = true)
        {
            ConsoleColor auxColor = Console.ForegroundColor;

            Console.ForegroundColor = ConsoleColor.Yellow;

            if (spaces)
                Console.Write(" " + (char)Symbols.ghost1 + player.prefix + "   ");
            else
                Console.Write("Y" + player.prefix);

            Console.ForegroundColor = auxColor;
        }

        internal override bool checkWinner(Ghosts ghost)
        {
            return ghost.color == ConsoleColor.Red;
        }
    }

    internal class RedGhost : Ghosts
    {
        internal RedGhost(Player player) : base(player) { color = ConsoleColor.Red; }

        internal override void Render(bool spaces = true)
        {
            ConsoleColor auxColor = Console.ForegroundColor;

            Console.ForegroundColor = ConsoleColor.Red;

            if (spaces)
                Console.Write(" " + (char)Symbols.ghost1 + player.prefix + "   ");
            else
                Console.Write("R" + player.prefix);

            Console.ForegroundColor = auxColor;
        }
        internal override bool checkWinner(Ghosts ghost)
        {
            return ghost.color == ConsoleColor.Blue;
        }
    }


    internal class BlueGhost : Ghosts
    {
        internal BlueGhost(Player player) : base(player) { color = ConsoleColor.Blue; }

        internal override void Render(bool spaces = true)
        {
            ConsoleColor auxColor = Console.ForegroundColor;

            Console.ForegroundColor = ConsoleColor.Blue;

            if (spaces)
                Console.Write(" " + (char)Symbols.ghost1 + player.prefix + "   ");
            else
                Console.Write("B" + player.prefix);

            Console.ForegroundColor = auxColor;
        }
        internal override bool checkWinner(Ghosts ghost)
        {
            return ghost.color == ConsoleColor.Yellow;
        }
    }
}
