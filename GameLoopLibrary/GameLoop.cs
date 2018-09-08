
namespace GameLoopLibrary
{
    public class GameLoop<Input>
    {
        private const double defaultFrameTime = (1.0 / 60) * 1000;
        private readonly IGame<Input> game;
        private readonly InputHandler<Input> inputHandler;
        private readonly ITimer timer;
        public double FrameTime { get; set; }

        public GameLoop(IGame<Input> game, InputHandler<Input> inputHandler, ITimer timer)
        {
            this.game = game;
            this.inputHandler = inputHandler;
            this.timer = timer;
            FrameTime = defaultFrameTime;
        }

        public void Run()
        {
            double previousTime = timer.GetTime();
            double lag = 0;

            while (game.Running)
            {
                double currentTime = timer.GetTime();
                lag += currentTime - previousTime;

                while (lag >= FrameTime)
                {
                    game.Update(inputHandler.CurrentInput);
                    lag -= FrameTime;
                }
                game.Render();

                previousTime = currentTime;
            }
        }
    }
}
