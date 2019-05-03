namespace Jogo18Ghosts
{
    internal class WinChecker
    {
        public State Check(GameBoard board)
        {
            if (CheckForWin(board, State.P1)) return State.P1;
            if (CheckForWin(board, State.P2)) return State.P2;
            return State.Undecided;
        }

        private bool CheckForWin(GameBoard board, State player)
        {
            for (int row = 0; row < 3; row++)
                if (AreAll(board, new Position[] {
                        new Position(row, 0),
                        new Position(row, 1),
                        new Position(row, 2) }, player))
                    return true;

            for (int column = 0; column < 3; column++)
                if (AreAll(board, new Position[] {
                        new Position(0, column),
                        new Position(1, column),
                        new Position(2, column) }, player))
                    return true;

            if (AreAll(board, new Position[] {
                    new Position(0, 0),
                    new Position(1, 1),
                    new Position(2, 2) }, player))
                return true;

            if (AreAll(board, new Position[] {
                    new Position(2, 0),
                    new Position(1, 1),
                    new Position(0, 2) }, player))
                return true;

            return false;

        }

        private bool AreAll(GameBoard board, Position[] positions, State state)
        {

            foreach (Position position in positions)
                if (board.GetState(position) != state) return false;

			return true;
        }

        public bool IsDraw(GameBoard board)
        {
            for (int row = 0; row < 3; row++)
                for (int column = 0; column < 3; column++)
                    if (board.GetState(new Position(row, column)) == State.Undecided) return false;

            return true;
        }
    } 
   }