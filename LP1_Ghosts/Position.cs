namespace Jogo18Ghosts
{
    /// <summary>
    /// this class is used to get and set the positions of the pieces on the
    /// board by row and column 
    /// </summary>
    public class Position
    {
        public int Row { set; get; }
        public int Col { set; get; }

        public Position(int row, int col)
        {
            Row = row;
            Col = col;
        }
    }
}