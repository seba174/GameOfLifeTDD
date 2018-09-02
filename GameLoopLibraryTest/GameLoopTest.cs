using GameLoopLibrary;
using Xunit;

namespace GameLoopLibraryTest
{
    public partial class GameLoopTest
    {
        private readonly TestGame testGame;
        private readonly TestInputHandler testInputHandler;
        private readonly GameLoop<TestInput> gameLoop;

        public GameLoopTest()
        {
            testGame = new TestGame();
            testInputHandler = new TestInputHandler();
            gameLoop = new GameLoop<TestInput>(testGame, testInputHandler);
        }

        [Fact]
        public void DoesNothingIfGameIsNotRunning()
        {
            testGame.EnqueRunningAnswers(false);

            gameLoop.Run();

            Assert.Equal(0, testGame.NumberOfUpdates);
        }

        [Fact]
        public void InvokesOneUpdateIfGameIsRunning()
        {
            testGame.EnqueRunningAnswers(true, false);

            gameLoop.Run();

            Assert.Equal(1, testGame.NumberOfUpdates);
        }

        [Fact]
        public void InvokesUpdatesAsLongAsGameIsRunning()
        {
            testGame.EnqueRunningAnswers(true, true, true, false);

            gameLoop.Run();

            Assert.Equal(3, testGame.NumberOfUpdates);
        }

        [Fact]
        public void InvokesRenderAfterUpdate()
        {
            testGame.EnqueRunningAnswers(true, false);

            gameLoop.Run();

            Assert.Equal(1, testGame.NumberOfRenders);
        }

        [Fact]
        public void PassesInputToUpdate()
        {
            TestInput testInput = new TestInput();
            testInputHandler.CurrentInput = testInput;
            testGame.EnqueRunningAnswers(true, false);

            gameLoop.Run();

            Assert.Same(testInput, testGame.UpdatedWithInput);
        }
    }
}
