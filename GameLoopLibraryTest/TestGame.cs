using System;
using System.Collections.Generic;
using GameLoopLibrary;

namespace GameLoopLibraryTest
{
    public class TestGame : IGame<TestInput>
    {
        public bool Running => runningAnswers.Dequeue();

        private Queue<bool> runningAnswers;

        public Action RenderAction { get; set; }

        public int NumberOfUpdates { get; set; }

        public int NumberOfRenders { get; set; }

        public TestInput UpdatedWithInput { get; set; }

        public TestGame()
        {
            NumberOfRenders = 0;
            NumberOfUpdates = 0;
            RenderAction = () => NumberOfRenders++;
        }

        public void Update(TestInput input)
        {
            NumberOfUpdates++;
            UpdatedWithInput = input;
        }

        public void Render()
        {
            RenderAction.Invoke();
        }

        public void EnqueRunningAnswers(params bool[] answers)
        {
            runningAnswers = new Queue<bool>(answers);
        }
    }
}
