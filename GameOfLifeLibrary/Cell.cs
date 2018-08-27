namespace GameOfLifeLibrary
{
    public class Cell
    {
        public CellState State { get; private set; }

        public Cell(CellState state)
        {
            this.State = state;
        }

        public CellState GetNextState(int numberOfNeighbours)
        {
            if (State.IsAlive())
            {
                return numberOfNeighbours == 2 || numberOfNeighbours == 3 ? CellState.Alive : CellState.Dead;
            }
            else
            {
                return numberOfNeighbours == 3 ? CellState.Alive : CellState.Dead;
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

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
