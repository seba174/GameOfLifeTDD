namespace GameOfLifeLibrary
{
    public class Cell
    {
        protected CellState state;

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
            return state == other.state;
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
