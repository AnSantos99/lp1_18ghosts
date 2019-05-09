using System;
namespace Jogo18Ghosts
{
    /// <summary>
    /// this class is used to define the portals and their actions on the board
    /// each portal starts off pointing towards a certain direction and then
    /// rotates whenever a ghost of its colour loses a fight. it is tied 
    /// to the BoardPiece class
    /// </summary>

    internal class Portals : BoardPiece
    {
        //setting the default direction as up from the Direction enum
        internal Direction dir = Direction.up;

        /// <summary>
        /// this class method sets the direction a given portal is facing 
        /// </summary>
        /// <param name="dir"></param>
        internal Portals(Direction dir)
        {
            this.dir = dir;
        }

        /// <summary>
        /// this method returns nothing. it's purpose is to turn the portal
        /// upon verifying what ghost has lost a battle, turning 90 degrees.
        /// </summary>
        internal void Turn()
        {
            //switch receives the direction the portal currently faces
            switch (dir)
            {
                case Direction.up:
                    dir = Direction.right;
                    break;
                case Direction.right:
                    dir = Direction.down;
                    break;
                case Direction.down:
                    dir = Direction.left;
                    break;
                case Direction.left:
                    dir = Direction.up;
                    break;
            }
        }

        /// <summary>
        /// this override method returns nothing. it renders the portals in
        /// their given place and rotation
        /// </summary>
        /// <param name="spaces"> spaces between corridor and portal</param>
        internal override void Render(bool spaces = true)
        {
            //getting the default colour
            ConsoleColor auxColor = Console.ForegroundColor;

            Console.ForegroundColor = this.color;

            //checking the direction the portal is facing to render correctly
            switch (dir)
            {
                case Direction.up:
                    prefix = "\u02C4";
                    break;
                case Direction.down:
                    prefix = "\u02C5";
                    break;
                case Direction.left:
                    prefix = "\u02C2";
                    break;
                case Direction.right:
                    prefix = "\u02C3";
                    break;
            }

            //render the spaces for cleaner output
            if (spaces)
                Console.Write(" " + prefix + "    ");
            else
                Console.Write(prefix);

            //return to printing the base colour
            Console.ForegroundColor = auxColor;
        }
    }

    /// <summary>
    /// this class derivates from the class RedPortal and sets the portal colour
    /// as red
    /// </summary>
    internal class RedPortal : Portals
    {
        /// <summary>
        /// this method sets the colour of this portal as red
        /// </summary>
        /// <param name="dir">the portal's current direction</param>
        internal RedPortal(Direction dir) : base(dir)
        {
            color = ConsoleColor.Red;
        }


    }

    /// <summary>
    /// this class derivates from the class BluePortal and sets the portal colour
    /// as blue
    /// </summary>
    internal class BluePortal : Portals
    {
        /// <summary>
        /// this method sets the colour of this portal as blue
        /// </summary>
        /// <param name="dir">the portal's current direction</param>
        internal BluePortal(Direction dir) : base(dir)
        {
            color = ConsoleColor.Blue;
        }


    }

    /// <summary>
    /// this class derivates from the class YellowPortal and sets the portal colour
    /// as yellow
    /// </summary>
    internal class YellowPortal : Portals
    {
        /// <summary>
        /// this method sets the colour of this portal as yellow
        /// </summary>
        /// <param name="dir">the portal's current direction</param>
        internal YellowPortal(Direction dir) : base(dir)
        {
            color = ConsoleColor.Yellow;
        }


    }
}
