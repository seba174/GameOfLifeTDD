using GameLoopLibrary;

namespace GameLoopLibraryTest
{
    public class TestInputHandler : InputHandler<TestInput>
    {
        public TestInput CurrentInput { get; set; }
    }
}
