using System;

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
            throw new NotImplementedException();
        }
    }
}