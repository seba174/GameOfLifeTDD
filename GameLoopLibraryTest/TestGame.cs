using System;
using System.Collections.Generic;
using GameLoopLibrary;

namespace GameLoopLibraryTest
{
    public class RenderBeforeUpdateException : Exception
    {
        public RenderBeforeUpdateException() { }

        public RenderBeforeUpdateException(string message) : base(message) { }

        public RenderBeforeUpdateException(string message, Exception innerException) : base(message, innerException) { }
    }

    public class TestGame : IGame<TestInput>
    {
        public bool Running => runningAnswers.Dequeue();

        private Queue<bool> runningAnswers;

        public int NumberOfUpdates { get; private set; }

        public int NumberOfRenders { get; private set; }

        public TestInput UpdatedWithInput { get; set; }

        public TestGame()
        {
            NumberOfRenders = 0;
            NumberOfUpdates = 0;
        }

        public void Update(TestInput input)
        {
            NumberOfUpdates++;
            UpdatedWithInput = input;
        }

        public void Render()
        {
            if (NumberOfRenders != NumberOfUpdates - 1)
            {
                throw new RenderBeforeUpdateException();
            }

            NumberOfRenders++;
        }

        public void EnqueRunningAnswers(params bool[] answers)
        {
            runningAnswers = new Queue<bool>(answers);
        }
    }
}
