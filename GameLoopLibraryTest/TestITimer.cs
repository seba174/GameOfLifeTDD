using GameLoopLibrary;

namespace GameLoopLibraryTest
{
    public class TestSecondsTimer : ITimer
    {
        private double currentTime;

        public TestSecondsTimer()
        {
            currentTime = 0.0;
        }

        public double GetTime()
        {
            return currentTime++;
        }
    }
}
