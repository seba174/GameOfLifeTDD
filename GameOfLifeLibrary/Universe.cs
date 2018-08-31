namespace GameOfLifeLibrary
{
    public class Universe
    {
        private Cell[,] State { get; set; }

        public Universe(Cell[,] cells) => State = cells;

        public CellState[,] GetState()
        {
            CellState[,] cellStates = new CellState[State.GetLength(0), State.GetLength(1)];
            for (int i = 0; i < State.GetLength(0); i++)
            {
                for (int j = 0; j < State.GetLength(1); j++)
                {
                    cellStates[i, j] = State[i, j].State;
                }
            }

            return cellStates;
        }

        public void Update()
        {
            int[,] aliveNeighboursCounts = GetAliveNeighboursCounts();
            for (int row = 0; row < State.GetLength(0); row++)
            {
                for (int col = 0; col < State.GetLength(1); col++)
                {
                    State[row, col].Update(aliveNeighboursCounts[row, col]);
                }
            }
        }

        private int[,] GetAliveNeighboursCounts()
        {
            int[,] aliveNeighboursCounts = new int[State.GetLength(0), State.GetLength(1)];
            for (int row = 0; row < State.GetLength(0); row++)
            {
                for (int col = 0; col < State.GetLength(1); col++)
                {
                    aliveNeighboursCounts[row, col] = GetNumberOfAliveNeighbours(row, col);
                }
            }
            return aliveNeighboursCounts;
        }

        private int GetNumberOfAliveNeighbours(int row, int col)
        {
            int numberOfAliveNeighbours = 0;

            numberOfAliveNeighbours += GetNumberOfAliveNeighboursInRow(row - 1, col);
            if (IsNeihbourAlive(row, col - 1))
                numberOfAliveNeighbours++;
            if (IsNeihbourAlive(row, col + 1))
                numberOfAliveNeighbours++;
            numberOfAliveNeighbours += GetNumberOfAliveNeighboursInRow(row + 1, col);

            return numberOfAliveNeighbours;
        }

        private int GetNumberOfAliveNeighboursInRow(int row, int col)
        {
            int numberOfAliveNeighbours = 0;

            if (IsNeihbourAlive(row, col - 1))
                numberOfAliveNeighbours++;
            if (IsNeihbourAlive(row, col))
                numberOfAliveNeighbours++;
            if (IsNeihbourAlive(row, col + 1))
                numberOfAliveNeighbours++;

            return numberOfAliveNeighbours;
        }

        private bool IsNeihbourAlive(int row, int col)
        {
            return GetCellStateSafely(row, col).IsAlive;
        }

        private CellState GetCellStateSafely(int row, int col)
        {
            return IsRowNumberValid(row) && IsColumnNumberValid(col) ? State[row, col].State : CellState.Dead;
        }

        private bool IsRowNumberValid(int row)
        {
            return row >= 0 && row < State.GetLength(0);
        }

        private bool IsColumnNumberValid(int col)
        {
            return col >= 0 && col < State.GetLength(1);
        }
    }
}