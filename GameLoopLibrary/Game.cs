
namespace GameLoopLibrary
{
    public interface IGame<Input>
    {
        bool Running { get; }

        void Update(Input input);

        void Render();
    }
}
