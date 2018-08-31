using System;

namespace GameOfLifeLibrary
{
    public class CellGridFactory
    {
        public static Cell[,] FromCellStateArray(CellState[,] states)
        {
            if (states is null)
            {
                throw new ArgumentNullException(nameof(states));
            }

            Cell[,] cells = new Cell[states.GetLength(0), states.GetLength(1)];
            for (int i = 0; i < cells.GetLength(0); i++)
            {
                for (int j = 0; j < cells.GetLength(1); j++)
                {
                    cells[i, j] = new Cell(states[i, j]);
                }
            }

            return cells;
        }
    }
}
