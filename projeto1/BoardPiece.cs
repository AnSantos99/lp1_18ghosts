using System;
namespace Jogo18Ghosts
{
    public class BoardPiece
    {
        protected string prefix;
        public ConsoleColor color;

        public BoardPiece()
            : this("", ConsoleColor.White)
        {
        }

        public BoardPiece(string prefix, ConsoleColor color)
        {
            this.prefix = prefix;
            this.color = color;
        }

        public virtual void Render()
        {
            ConsoleColor auxColor = Console.ForegroundColor;

            Console.ForegroundColor = this.color;
            Console.Write(" " + prefix + "    ");

            Console.ForegroundColor = auxColor;
        }
    }
}
