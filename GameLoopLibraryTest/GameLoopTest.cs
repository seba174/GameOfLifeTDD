using System;
using GameLoopLibrary;
using Xunit;

namespace GameLoopLibraryTest
{
    public class GameLoopTest
    {
        private readonly TestGame testGame;
        private readonly TestInputHandler testInputHandler;
        private readonly GameLoop<TestInput> gameLoop;
        private readonly TestSecondsTimer testTimer;

        public GameLoopTest()
        {
            testGame = new TestGame();
            testInputHandler = new TestInputHandler();
            testTimer = new TestSecondsTimer();

            gameLoop = new GameLoop<TestInput>(testGame, testInputHandler, testTimer)
            {
                FrameTime = 1.0
            };
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
            testGame.RenderAction = () =>
            {
                if (testGame.NumberOfRenders != testGame.NumberOfUpdates - 1)
                {
                    throw new RenderBeforeUpdateException();
                }
                testGame.NumberOfRenders++;
            };

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

        [Fact]
        public void ShouldSkipUpdateIfLoopIsTooFast()
        {
            testGame.EnqueRunningAnswers(true, false);
            gameLoop.FrameTime = 2.0;

            gameLoop.Run();

            Assert.Equal(0, testGame.NumberOfUpdates);
            Assert.Equal(1, testGame.NumberOfRenders);
        }

        [Fact]
        public void ShouldDoAdditionalUpdateIfLoopIsTooSlow()
        {
            testGame.EnqueRunningAnswers(true, false);
            gameLoop.FrameTime = 0.5;

            gameLoop.Run();

            Assert.Equal(2, testGame.NumberOfUpdates);
            Assert.Equal(1, testGame.NumberOfRenders);
        }

        [Fact]
        public void DoesExecuteUpdateEventually()
        {
            testGame.EnqueRunningAnswers(true, true, true, false);
            gameLoop.FrameTime = 2.0;

            gameLoop.Run();

            Assert.True(testGame.NumberOfUpdates > 0);
        }
    }

    public class RenderBeforeUpdateException : Exception
    {
        public RenderBeforeUpdateException() { }

        public RenderBeforeUpdateException(string message) : base(message) { }

        public RenderBeforeUpdateException(string message, Exception innerException) : base(message, innerException) { }
    }
}
