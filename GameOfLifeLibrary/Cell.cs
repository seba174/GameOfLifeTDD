using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLifeLibrary
{
    public class Cell
    {
        private CellState state;

        public enum CellState
        {
            Alive,
            Dead
        }

        public Cell(CellState state)
        {
            this.state = state;
        }

        public CellState GetNextState(int numberOfNeighbours)
        {
            if (state == CellState.Alive)
                return numberOfNeighbours == 2 || numberOfNeighbours == 3 ? CellState.Alive : CellState.Dead;
            else
                return numberOfNeighbours == 3 ? CellState.Alive : CellState.Dead;
        }
    }
}
