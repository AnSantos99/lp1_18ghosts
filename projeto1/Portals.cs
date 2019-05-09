using System;
namespace Jogo18Ghosts
{
    /// <summary>
    /// this class is used to define the portals and their actions on the board
    /// each portal starts off pointing towards a certain direction and then
    /// rotates whenever a ghost of its colour loses a fight
    /// </summary>
    internal class Portals : BoardPiece
    {
        internal Direction dir = Direction.up;

        internal Portals(Direction dir)
        {
            this.dir = dir;
        }

        internal void Turn()
        {
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

        internal override void Render(bool spaces = true)
        {
            ConsoleColor auxColor = Console.ForegroundColor;

            Console.ForegroundColor = this.color;
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

            if (spaces)
                Console.Write(" " + prefix + "    ");
            else
                Console.Write(prefix);

            Console.ForegroundColor = auxColor;
        }
    }

    internal class RedPortal : Portals
    {
        internal RedPortal(Direction dir) : base(dir)
        {
            color = ConsoleColor.Red;
        }


    }

    internal class BluePortal : Portals
    {
        internal BluePortal(Direction dir) : base(dir)
        {
            color = ConsoleColor.Blue;
        }


    }

    internal class YellowPortal : Portals
    {
        internal YellowPortal(Direction dir) : base(dir)
        {
            color = ConsoleColor.Yellow;
        }


    }
}
