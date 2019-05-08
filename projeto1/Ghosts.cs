using System;
using System.Text;

namespace Jogo18Ghosts
{
    abstract public class Ghosts : BoardPiece
    {
        public Position pos;
        public PlayerFix player;


        public Ghosts(PlayerFix player)
        {
            this.player = player;
        }

        abstract public bool checkWinner(Ghosts ghost);


    }

    public sealed class YellowGhost : Ghosts
    {
        public YellowGhost(PlayerFix player) : base(player) { color = ConsoleColor.Yellow; }

        public override void Render()
        {
            ConsoleColor auxColor = Console.ForegroundColor;

            Console.ForegroundColor = ConsoleColor.Yellow;

            Console.Write(" Y" + player.prefix + "   ");

            Console.ForegroundColor = auxColor;
        }
        public override bool checkWinner(Ghosts ghost)
        {
            return ghost.color == ConsoleColor.Red;
        }
    }

    public sealed class RedGhost : Ghosts
    {
        public RedGhost(PlayerFix player) : base(player) { color = ConsoleColor.Red; }

        public override void Render()
        {
            ConsoleColor auxColor = Console.ForegroundColor;

            Console.ForegroundColor = ConsoleColor.Red;

            Console.Write(" R" + player.prefix + "   ");

            Console.ForegroundColor = auxColor;
        }
        public override bool checkWinner(Ghosts ghost)
        {
            return ghost.color == ConsoleColor.Blue;
        }
    }

    public sealed class BlueGhost : Ghosts
    {
        public BlueGhost(PlayerFix player) : base(player) { color = ConsoleColor.Blue; }

        public override void Render()
        {
            ConsoleColor auxColor = Console.ForegroundColor;

            Console.ForegroundColor = ConsoleColor.Blue;

            Console.Write(" B" + player.prefix + "   ");

            Console.ForegroundColor = auxColor;
        }
        public override bool checkWinner(Ghosts ghost)
        {
            return ghost.color == ConsoleColor.Yellow;
        }
    }
}
