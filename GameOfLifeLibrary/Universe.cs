namespace GameOfLifeLibrary
{
    public class Universe
    {
        private Cell[,] State { get; set; }

        public Universe(Cell[,] cells)
        {
            State = cells;
        }

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
            CellState[,] originalState = GetState();
            for (int row = 0; row < State.GetLength(0); row++)
            {
                for (int col = 0; col < State.GetLength(1); col++)
                {
                    int numberOfAliveNeighbours = GetNumberOfAliveNeighbours(originalState, row, col);
                    State[row, col].Update(numberOfAliveNeighbours);
                }
            }
        }

        private int GetNumberOfAliveNeighbours(CellState[,] state, int row, int col)
        {
            int numberOfAliveNeighbours = 0;

            numberOfAliveNeighbours += GetNumberOfAliveNeighboursInRow(state, row - 1, col);
            numberOfAliveNeighbours += GetCountIfCellIsAlive(state, row, col - 1);
            numberOfAliveNeighbours += GetCountIfCellIsAlive(state, row, col + 1);
            numberOfAliveNeighbours += GetNumberOfAliveNeighboursInRow(state, row + 1, col);

            return numberOfAliveNeighbours;
        }

        private int GetNumberOfAliveNeighboursInRow(CellState[,] state, int row, int col)
        {
            int numberOfAliveNeighbours = 0;

            if (row >= 0 && row < state.GetLength(0))
            {
                numberOfAliveNeighbours += GetCountIfCellIsAlive(state, row, col - 1);
                numberOfAliveNeighbours += GetCountIfCellIsAlive(state, row, col);
                numberOfAliveNeighbours += GetCountIfCellIsAlive(state, row, col + 1);
            }

            return numberOfAliveNeighbours;
        }

        private int GetCountIfCellIsAlive(CellState[,] state, int row, int col)
        {
            if (col >= 0 && col < state.GetLength(1))
            {
                if (state[row, col].IsAlive())
                {
                    return 1;
                }
            }
            return 0;
        }
    }
}