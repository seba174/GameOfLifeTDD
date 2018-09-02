
namespace GameLoopLibrary
{
    public class GameLoop<Input>
    {
        private IGame<Input> Game { get; set; }
        private InputHandler<Input> InputHandler { get; set; }

        public GameLoop(IGame<Input> game, InputHandler<Input> inputHandler)
        {
            Game = game;
            InputHandler = inputHandler;
        }

        public void Run()
        {
            while (Game.Running)
            {
                Game.Update(InputHandler.CurrentInput);
                Game.Render();
            }
        }
    }
}
