using System.Collections.Generic;
using GameOfLifeLibrary;
using Xunit;

namespace GameOfLifeLibraryTests
{
    public class CellTest
    {
        public class StateProperty
        {
            public static IEnumerable<object[]> States =
                new List<object[]>
                {
                    new object[] {CellState.Alive},
                    new object[] {CellState.Dead}
                };

            [Theory]
            [MemberData(nameof(States))]
            public void ShouldReturnItsState(CellState initial)
            {
                Cell cell = new Cell(initial);

                Assert.Equal(initial, cell.State);
            }
        }

        public class GetNextStateMethod
        {
            public static IEnumerable<object[]> AliveTestData =
                new List<object[]>
                {
                    new object[] {0, CellState.Dead},
                    new object[] {1, CellState.Dead},
                    new object[] {2, CellState.Alive},
                    new object[] {3, CellState.Alive},
                    new object[] {4, CellState.Dead},
                    new object[] {5, CellState.Dead},
                    new object[] {6, CellState.Dead},
                    new object[] {7, CellState.Dead},
                    new object[] {8, CellState.Dead}
                };

            public static IEnumerable<object[]> DeadTestData =
                new List<object[]>
                {
                    new object[] {0, CellState.Dead},
                    new object[] {1, CellState.Dead},
                    new object[] {2, CellState.Dead},
                    new object[] {3, CellState.Alive},
                    new object[] {4, CellState.Dead},
                    new object[] {5, CellState.Dead},
                    new object[] {6, CellState.Dead},
                    new object[] {7, CellState.Dead},
                    new object[] {8, CellState.Dead}
                 };

            [Theory]
            [MemberData(nameof(AliveTestData))]
            public void ShouldFullfillTransitionWhenAlive(int numberOfNeighbours, CellState expected)
            {
                Cell cell = new Cell(CellState.Alive);

                CellState actual = cell.GetNextState(numberOfNeighbours);

                Assert.Equal(expected, actual);
            }

            [Theory]
            [MemberData(nameof(DeadTestData))]
            public void ShouldFullfillTransitionWhenDead(int numberOfNeighbours, CellState expected)
            {
                Cell cell = new Cell(CellState.Dead);

                CellState actual = cell.GetNextState(numberOfNeighbours);

                Assert.Equal(expected, actual);
            }
        }

        public class EqualsMethod
        {
            [Fact]
            public void ShouldNotEqualsNull()
            {
                Cell cell = new Cell(CellState.Alive);

                bool equals = cell.Equals(null);

                Assert.False(equals);
            }

            [Fact]
            public void ShouldNotEqualWithDifferentCellState()
            {
                Cell cell = new Cell(CellState.Alive);

                bool equals = cell.Equals(new Cell(CellState.Dead));

                Assert.False(equals);
            }

            [Fact]
            public void ShouldEqualWithSameCellState()
            {
                Cell cell = new Cell(CellState.Alive);

                bool equals = cell.Equals(new Cell(CellState.Alive));

                Assert.True(equals);
            }
        }

        public class EqualsObjectMethod
        {
            public class CellInheritanceTest : Cell
            {
                public CellInheritanceTest(CellState cellState) : base(cellState) { }
            }

            [Fact]
            public void ShouldNotEqualsNull()
            {
                Cell cell = new Cell(CellState.Alive);

                bool equals = ((object)cell).Equals(null);

                Assert.False(equals);
            }

            [Fact]
            public void ShouldNotEqualWithDifferentCellState()
            {
                Cell cell = new Cell(CellState.Alive);

                bool equals = ((object)cell).Equals(new Cell(CellState.Dead));

                Assert.False(equals);
            }

            [Fact]
            public void ShouldEqualWithSameCellState()
            {
                Cell cell = new Cell(CellState.Alive);

                bool equals = ((object)cell).Equals(new Cell(CellState.Alive));

                Assert.True(equals);
            }

            [Fact]
            public void ShouldNotEqualWithSameCellStateButInheritedClass()
            {
                Cell cell = new Cell(CellState.Alive);

                bool equals = ((object)cell).Equals(new CellInheritanceTest(CellState.Alive));

                Assert.False(equals);
            }
        }
    }
}
