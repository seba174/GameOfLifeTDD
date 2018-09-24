using System;
using GameLoopLibrary;
using Xunit;
using FakeItEasy;

namespace GameLoopLibraryTest
{
    public class GameLoopTest
    {
        private readonly IGame<TestInput> testGame;
        private readonly InputHandler<TestInput> testInputHandler;
        private readonly GameLoop<TestInput> gameLoop;
        private readonly ITimer testTimer;

        public GameLoopTest()
        {
            testGame = A.Fake<IGame<TestInput>>();
            testInputHandler = A.Fake<InputHandler<TestInput>>();
            testTimer = A.Fake<ITimer>();

            double time = 0.0;
            A.CallTo(() => testTimer.GetTime()).ReturnsLazily(() => time++);

            gameLoop = new GameLoop<TestInput>(testGame, testInputHandler, testTimer)
            {
                FrameTime = 1.0
            };
        }

        [Fact]
        public void DoesNothingIfGameIsNotRunning()
        {
            A.CallTo(() => testGame.Running).Returns(false);

            gameLoop.Run();

            A.CallTo(() => testGame.Update(A<TestInput>.Ignored)).MustNotHaveHappened();
        }

        [Fact]
        public void InvokesOneUpdateIfGameIsRunning()
        {
            A.CallTo(() => testGame.Running).ReturnsNextFromSequence(true, false);

            gameLoop.Run();

            A.CallTo(() => testGame.Update(A<TestInput>.Ignored)).MustHaveHappened(Repeated.Exactly.Once);
        }

        [Fact]
        public void InvokesUpdatesAsLongAsGameIsRunning()
        {
            A.CallTo(() => testGame.Running).ReturnsNextFromSequence(true, true, true, false);

            gameLoop.Run();

            A.CallTo(() => testGame.Update(A<TestInput>.Ignored)).MustHaveHappened(Repeated.Exactly.Times(3));
        }

        [Fact]
        public void InvokesRenderAfterUpdate()
        {
            A.CallTo(() => testGame.Running).ReturnsNextFromSequence(true, false);

            gameLoop.Run();

            A.CallTo(() => testGame.Update(A<TestInput>.Ignored)).MustHaveHappened()
                .Then(A.CallTo(() => testGame.Render()).MustHaveHappened());
        }

        [Fact]
        public void PassesInputToUpdate()
        {
            TestInput testInput = new TestInput();
            A.CallTo(() => testInputHandler.CurrentInput).Returns(testInput);
            A.CallTo(() => testGame.Running).ReturnsNextFromSequence(true, false);

            gameLoop.Run();

            A.CallTo(() => testGame.Update(testInput)).MustHaveHappened();
        }

        [Fact]
        public void ShouldSkipUpdateIfLoopIsTooFast()
        {
            A.CallTo(() => testGame.Running).ReturnsNextFromSequence(true, false);
            gameLoop.FrameTime = 2.0;

            gameLoop.Run();

            A.CallTo(() => testGame.Update(A<TestInput>.Ignored)).MustNotHaveHappened();
            A.CallTo(() => testGame.Render()).MustHaveHappened();
        }

        [Fact]
        public void ShouldDoAdditionalUpdateIfLoopIsTooSlow()
        {
            A.CallTo(() => testGame.Running).ReturnsNextFromSequence(true, false);
            gameLoop.FrameTime = 0.5;

            gameLoop.Run();

            A.CallTo(() => testGame.Update(A<TestInput>.Ignored)).MustHaveHappened(Repeated.Exactly.Times(2));
            A.CallTo(() => testGame.Render()).MustHaveHappened(Repeated.Exactly.Times(1));
        }

        [Fact]
        public void DoesExecuteUpdateEventually()
        {
            A.CallTo(() => testGame.Running).ReturnsNextFromSequence(true, true, true, false);
            gameLoop.FrameTime = 2.0;

            gameLoop.Run();

            A.CallTo(() => testGame.Update(A<TestInput>.Ignored)).MustHaveHappened();
        }
    }

    public class RenderBeforeUpdateException : Exception
    {
        public RenderBeforeUpdateException() { }

        public RenderBeforeUpdateException(string message) : base(message) { }

        public RenderBeforeUpdateException(string message, Exception innerException) : base(message, innerException) { }
    }
}
