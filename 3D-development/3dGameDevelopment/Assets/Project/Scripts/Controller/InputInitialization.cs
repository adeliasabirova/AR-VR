namespace Project
{
    internal sealed class InputInitialization : IInitialize
    {
        private IUserInputProxy _pcInputHorizontal;
        private IUserInputProxy _pcInputVertical;
        private IUserInputProxy _pcInputMouseX;
        private IUserButtonInputProxy _pcInputJump;

        public InputInitialization()
        {
            _pcInputHorizontal = new PCInputHorizontal();
            _pcInputVertical = new PCInputVertical();
            _pcInputMouseX = new PCInputMouseX();
            _pcInputJump = new PCInputJump();
        }

        public void Initialize()
        { }

        public (IUserInputProxy inputHorizontal, IUserInputProxy inputVertical, IUserInputProxy inputMouseX, IUserButtonInputProxy inputJump) GetInput()
        {
            (IUserInputProxy inputHorizontal, IUserInputProxy inputVertical, IUserInputProxy inputMouseX, IUserButtonInputProxy inputJump) result = (_pcInputHorizontal, _pcInputVertical, _pcInputMouseX, _pcInputJump);
            return result;
        }
    }
}
