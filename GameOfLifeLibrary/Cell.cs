using System;

namespace GameOfLifeLibrary
{
    public class Cell
    {
        public CellState State { get; private set; }

        public Cell(CellState state)
        {
            this.State = state;
        }

        public void Update(int numberOfNeighbours)
        {
            if (State.IsAlive())
            {
                State = numberOfNeighbours == 2 || numberOfNeighbours == 3 ? CellState.Alive : CellState.Dead;
            }
            else
            {
                State = numberOfNeighbours == 3 ? CellState.Alive : CellState.Dead;
            }
        }

        public bool Equals(Cell other)
        {
            if (other is null)
            {
                return false;
            }
            return State == other.State;
        }

        public override bool Equals(object obj)
        {
            if (obj is null || obj.GetType() != GetType())
            {
                return false;
            }
            return Equals(obj as Cell);
        }

        public override int GetHashCode() => base.GetHashCode();
    }
}
