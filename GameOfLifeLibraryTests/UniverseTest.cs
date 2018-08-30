using GameOfLifeLibrary;
using Xunit;

namespace GameOfLifeLibraryTests
{
    public class UniverseTest
    {
        private static readonly CellState O = CellState.Dead;
        private static readonly CellState X = CellState.Alive;

        public class GetStateMethod
        {
            [Fact]
            public void ShouldStoreItsInitialState()
            {
                CellState[,] original = new CellState[,] {
                { X, O, X },
                { O, O, X },
                { X, O, X }
            };
                Universe universe = new Universe(CellGridFactory.FromCellStateArray(original));

                CellState[,] actual = universe.GetState();

                Assert.Equal(original, actual);
            }
        }

        public class UpdateMethod
        {
            [Fact]
            public void ShouldUpdateItsState()
            {
                Universe universe = new Universe(CellGridFactory.FromCellStateArray(new CellState[,] { { X } }));

                universe.Update();
                CellState[,] actual = universe.GetState();

                Assert.Equal(new CellState[,] { { O } }, actual);
            }

            [Fact]
            public void ShouldUpdateAllCells()
            {
                Universe universe = new Universe(CellGridFactory.FromCellStateArray(
                    new CellState[,]
                    {
                        { X, X, X, O },
                        { O, X, O, O },
                        { X, O, X, X },
                        { O, O, X, X }
                    }));
                CellState[,] expected =
                    new CellState[,]
                    {
                        { X, X, X, O },
                        { O, O, O, X },
                        { O, O, O, X },
                        { O, X, X, X }
                    };

                universe.Update();
                CellState[,] actual = universe.GetState();

                Assert.Equal(expected, actual);
            }
        }
    }
}
