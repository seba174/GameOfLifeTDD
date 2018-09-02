
namespace GameLoopLibrary
{
#pragma warning disable IDE1006 // Naming Styles
    public interface InputHandler<Input>
#pragma warning restore IDE1006 // Naming Styles
    {
        Input CurrentInput { get; }
    }
}
