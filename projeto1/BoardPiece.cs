using System;
namespace Jogo18Ghosts
{
    /// <summary>
    /// this class checks the position of each piece and renders it depending
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
        /// <param name="prefix">checks the type of piece</param>
        /// <param name="color">checks the colour of the piece</param>
        internal BoardPiece(string prefix, ConsoleColor color)
        {
            this.prefix = prefix;
            this.color = color;
        }

        /// <summary>
        /// this method renders the pieces on the board according to what 
        /// informatioñ it gets about the piece type
        /// </summary>
        /// <param name="spaces">spaces between piece and corridor</param>
        internal virtual void Render(bool spaces = true)
        {
            // gets default console colour
            ConsoleColor auxColour = Console.ForegroundColor;

            Console.ForegroundColor = this.color;
            
            // rendering the spaces and piece properly
            if (spaces)
                Console.Write(" " + prefix + "    ");
            else
                Console.Write(prefix);
            
            // return to default colour for the rest of the board
            Console.ForegroundColor = auxColour;
        }
    }
}
