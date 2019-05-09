using System;
namespace Jogo18Ghosts
{
    public class Portals : BoardPiece
    {
        public enum Direction
        {
            up,
            down,
            left,
            right
        }

        public Direction dir = Direction.up;

        public Portals(Direction dir)
        {
            this.dir = dir;
        }

        public override void Render()
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
            Console.Write(" " + prefix + "    ");

            Console.ForegroundColor = auxColor;
        }
    }

    public class RedPortal : Portals
    {
        public RedPortal(Direction dir) : base(dir)
        {
            color = ConsoleColor.Red;
        }


    }

    public class BluePortal : Portals
    {
        public BluePortal(Direction dir) : base(dir)
        {
            color = ConsoleColor.Blue;
        }


    }

    public class YellowPortal : Portals
    {
        public YellowPortal(Direction dir) : base(dir)
        {
            color = ConsoleColor.Yellow;
        }


    }
}
