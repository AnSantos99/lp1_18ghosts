using System;

namespace Jogo18Ghosts
{
    /// <summary>
    /// this class derivates from the BoardPiece class and sets the ghosts for
    /// each player according to their colour and positions
    /// </summary>
    abstract internal class Ghosts : BoardPiece 
    {
        //calling the Player class
        internal Player player;

        /// <summary>
        /// this method returns nothing. it gets the current player
        /// </summary>
        /// <param name="player">checks the current player</param>
        internal Ghosts(Player player)
        {
            this.player = player;
        }

        //to check what player has won the game
        abstract internal bool checkWinner(Ghosts ghost);

    }

    /// <summary>
    /// this class obtains the player and their current ghost's colour, 
    /// rendering it as the prefix (the current player number) and the 
    /// respective colour properly it then has a method to check which ghost
    /// it's facing against on the next position to see which one wins
    /// </summary>
    internal class YellowGhost : Ghosts
    {
        /// <summary>
        /// this method derivates from the ghost class and takes the player
        /// to give them the yellow ghost
        /// </summary>
        /// <param name="player">gets the current player</param>
        internal YellowGhost(Player player) : base(player)
        {color = ConsoleColor.Yellow; }

        /// <summary>
        /// this method renders the ghost by placing spaces and then the ghost
        /// between the corridors to properly print the board
        /// </summary>
        /// <param name="spaces">spaces between ghost and corridor</param>
        internal override void Render(bool spaces = true)
        {
            //get the default colour
            ConsoleColor auxColour = Console.ForegroundColor;

            //set the colour to yellow for the ghost
            Console.ForegroundColor = ConsoleColor.Yellow;

            //place the ghost or the spaces
            if (spaces)
                Console.Write(" " + (char)Symbols.ghost + player.prefix + "   ");
            else
                Console.Write("Y" + player.prefix);

            //change back to the default colour
            Console.ForegroundColor = auxColour;
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
            ConsoleColor auxColour = Console.ForegroundColor;

            Console.ForegroundColor = ConsoleColor.Red;

            if (spaces)
                Console.Write(" " + (char)Symbols.ghost + player.prefix + "   ");
            else
                Console.Write("R" + player.prefix);

            Console.ForegroundColor = auxColour;
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
            ConsoleColor auxColour = Console.ForegroundColor;

            Console.ForegroundColor = ConsoleColor.Blue;

            if (spaces)
                Console.Write(" " + (char)Symbols.ghost + player.prefix + "   ");
            else
                Console.Write("B" + player.prefix);

            Console.ForegroundColor = auxColour;
        }
        internal override bool checkWinner(Ghosts ghost)
        {
            return ghost.color == ConsoleColor.Yellow;
        }
    }
}
