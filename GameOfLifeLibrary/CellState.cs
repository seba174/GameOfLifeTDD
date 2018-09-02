
namespace GameOfLifeLibrary
{
    public class CellState
    {
        public static CellState Alive = new CellState(0);
        public static CellState Dead = new CellState(1);

        private readonly int value;

        public bool IsAlive => this == Alive;

        public bool Equals(CellState other)
        {
            return other is null ? false : value == other.value;
        }

        public override bool Equals(object obj)
        {
            if (obj is null)
            {
                return false;
            }

            if (obj.GetType() != this.GetType())
            {
                return false;
            }

            return Equals(obj as CellState);
        }

        public override int GetHashCode() => value.GetHashCode();

        private CellState() { }

        private CellState(int value) => this.value = value;
    }
}
