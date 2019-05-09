﻿using System;

namespace Jogo18Ghosts
{
    /// <summary>
    /// this class' purpose is to set the mirrors on the board by giving them
    /// their character and colour for the render
    /// </summary>
    sealed internal class Mirror : BoardPiece
    {
        internal Mirror()
            : base(Convert.ToString((char)Symbols.mirror), ConsoleColor.White)
        {
        }
    }
}