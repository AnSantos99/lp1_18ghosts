namespace Jogo18Ghosts
{
    /// <summary>
    /// this class is used to get and set the positions of the pieces on the
    /// board by row and column 
    /// </summary>
    internal class Position
    {
        internal int Row { set; get; }
        internal int Col { set; get; }

        internal Position(int row, int col)
        {
            Row = row;
            Col = col;
        }
    }
}