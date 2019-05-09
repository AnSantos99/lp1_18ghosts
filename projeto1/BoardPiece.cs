using System;
namespace Jogo18Ghosts
{
    /// <summary>
    /// This class checks the position of each piece and renders it depending
    /// on the type of piece
    /// </summary>
    internal class BoardPiece
    {
        internal Position pos;
        protected string prefix;
        internal ConsoleColor color;

        /// <summary>
        /// this method returns the default board piece
        /// </summary>
        internal BoardPiece()
            : this("", ConsoleColor.White)
        {
        }

        /// <summary>
        /// this method gets each piece's type to set it's character and colour
        /// on the board
        /// </summary>
        /// <param name="prefix"></param>
        /// <param namC:\Users\nani\Desktop\LP1_Ghosts\LP1_Ghosts\BoardPiece.cse="color"></param>
        internal BoardPiece(string prefix, ConsoleColor color)
        {
            this.prefix = prefix;
            this.color = color;
        }

        /// <summary>
        /// this method renders the pieces on the board according to what information
        /// it gets about the piece type
        /// </summary>
        /// <param name="spaces"></param>
        internal virtual void Render(bool spaces = true)
        {
            ConsoleColor auxColor = Console.ForegroundColor;

            Console.ForegroundColor = this.color;
            if (spaces)
                Console.Write(" " + prefix + "    ");
            else
                Console.Write(prefix);

            Console.ForegroundColor = auxColor;
        }
    }
}
