namespace Game
{
    internal sealed class InputInitialization : IInitialize
    {
        private IUserInputProxy _pcInputHorizontal;
        private IUserInputProxy _pcInputVertical;
        private IUserInputProxy _pcInputMouseX;
        private IUserInputProxy _pcInputMouseY;
        private IUserButtonInputProxy _pcInputJump;

        public InputInitialization()
        {
            _pcInputHorizontal = new PCInputHorizontal();
            _pcInputVertical = new PCInputVertical();
            _pcInputMouseX = new PCInputMouseX();
            _pcInputMouseY = new PCInputMouseY();
            _pcInputJump = new PCInputJump();
        }

        public void Initialize()
        { }

        public (IUserInputProxy inputHorizontal, IUserInputProxy inputVertical, IUserInputProxy inputMouseX, IUserInputProxy inputMouseY, IUserButtonInputProxy inputJump) GetInput()
        {
            (IUserInputProxy inputHorizontal, IUserInputProxy inputVertical, IUserInputProxy inputMouseX, IUserInputProxy inputMouseY, IUserButtonInputProxy inputJump) result = (_pcInputHorizontal, _pcInputVertical, _pcInputMouseX, _pcInputMouseY, _pcInputJump);
            return result;
        }
    }
}
