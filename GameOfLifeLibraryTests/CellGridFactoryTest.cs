using System;
using System.Collections.Generic;
using GameOfLifeLibrary;
using Xunit;

namespace GameOfLifeLibraryTests
{
    public class CellGridFactoryTest
    {
        public class FromCellStateArrayMethod
        {
            public class FromCellStateArrayMethodTestData
            {
                public static object[] GenereteDataGrids(int rows, int columns)
                {
                    CellState[,] cellStates = new CellState[rows, columns];
                    Cell[,] cells = new Cell[rows, columns];
                    for (int i = 0; i < rows; i++)
                    {
                        for (int j = 0; j < columns; j++)
                        {
                            CellState state = (i + j) % 2 == 0 ? CellState.Alive : CellState.Dead;
                            cellStates[i, j] = state;
                            cells[i, j] = new Cell(state);
                        }
                    }
                    return new object[] { cellStates, cells };
                }

                public static IEnumerable<object[]> TestData =>
                    new List<object[]>
                    {
                        GenereteDataGrids(0, 0),
                        GenereteDataGrids(4, 4),
                        GenereteDataGrids(5, 4),
                        GenereteDataGrids(3, 5)
                    };
            }

            [Fact]
            public void ShouldThrowArgumentNullExceptionWhenNullIsPassed()
            {
                Action action = () => CellGridFactory.FromCellStateArray(null);

                Assert.Throws<ArgumentNullException>(action);
            }

            [Theory]
            [MemberData(nameof(FromCellStateArrayMethodTestData.TestData), MemberType = typeof(FromCellStateArrayMethodTestData))]
            public void ShouldReturnArrayOfCellsWithSameCellStates(CellState[,] initial, Cell[,] expected)
            {
                Cell[,] result = CellGridFactory.FromCellStateArray(initial);

                Assert.Equal(expected, result);
            }
        }
    }
}
