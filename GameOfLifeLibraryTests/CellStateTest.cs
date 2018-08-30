using GameOfLifeLibrary;
using Xunit;

namespace GameOfLifeLibraryTests
{
    public class CellStateTest
    {
        public class IsAliveMethod
        {
            [Fact]
            public void ShouldBeAliveWhenAliveCellState()
            {
                bool isAlive = CellState.Alive.IsAlive();

                Assert.True(isAlive);
            }

            [Fact]
            public void ShouldNotBeAliveWhenDeadCellState()
            {
                bool isAlive = CellState.Dead.IsAlive();

                Assert.False(isAlive);
            }
        }

        public class EqualsMethod
        {
            [Fact]
            public void ShouldNotEqualsNull()
            {
                CellState initial = CellState.Alive;

                bool equals = initial.Equals(null);

                Assert.False(equals);
            }

            [Fact]
            public void ShouldNotEqualWithDifferentCellStates()
            {
                CellState initial = CellState.Alive;

                bool equals = initial.Equals(CellState.Dead);

                Assert.False(equals);
            }

            [Fact]
            public void ShouldEqualWithSameCellState()
            {
                CellState initial = CellState.Alive;

                bool equals = initial.Equals(CellState.Alive);

                Assert.True(equals);
            }
        }

        public class EqualsObjectMethod
        {
            [Fact]
            public void ShouldNotEqualsNull()
            {
                CellState initial = CellState.Alive;

                bool equals = ((object)initial).Equals(null);

                Assert.False(equals);
            }

            [Fact]
            public void ShouldNotEqualWithDifferentCellState()
            {
                CellState initial = CellState.Alive;

                bool equals = ((object)initial).Equals(CellState.Dead);

                Assert.False(equals);
            }

            [Fact]
            public void ShouldEqualWithSameCellState()
            {
                CellState initial = CellState.Alive;

                bool equals = ((object)initial).Equals(CellState.Alive);

                Assert.True(equals);
            }

            [Fact]
            public void ShouldNotEqualWithDifferentType()
            {
                CellState initial = CellState.Alive;

                bool equals = ((object)initial).Equals(new Cell(CellState.Alive));

                Assert.False(equals);
            }
        }
    }
}
