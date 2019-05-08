using System;
namespace Jogo18Ghosts
{
    internal class Corridors
    {
        internal Colour Colour { get; set; }
        internal Position Position { get; set; }
        internal Symbol Symbol { get; set; }

        internal Corridors(Symbol symbol)
        {
            Symbol = symbol;
        }

        internal Corridors(Corridors corridor, Colour colour, Position position)
        {
            Corridor = corridor;
            Colour = colour;
            Position = position;

        }
    }
}
