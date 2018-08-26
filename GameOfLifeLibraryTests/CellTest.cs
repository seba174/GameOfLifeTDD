using System;
using Xunit;
using GameOfLifeLibrary;
using static GameOfLifeLibrary.Cell;
using System.Collections.Generic;

namespace GameOfLifeLibraryTest
{
    public class CellTest
    {
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
    }
}
