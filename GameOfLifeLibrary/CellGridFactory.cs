using System;
using static GameOfLifeLibrary.Cell;

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

            Cell[,] cellGrid = new Cell[states.GetLength(0), states.GetLength(1)];
            for (int i = 0; i < cellGrid.GetLength(0); i++)
            {
                for (int j = 0; j < cellGrid.GetLength(1); j++)
                {
                    cellGrid[i, j] = new Cell(states[i, j]);
                }
            }

            return cellGrid;
        }
    }
}
