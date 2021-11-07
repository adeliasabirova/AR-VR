namespace Project
{
    internal sealed class InputInitialization : IInitialize
    {
        private IUserInputProxy _pcInputHorizontal;
        private IUserInputProxy _pcInputVertical;
        private IUserInputProxy _pcInputMouseX;

        public InputInitialization()
        {
            _pcInputHorizontal = new PCInputHorizontal();
            _pcInputVertical = new PCInputVertical();
            _pcInputMouseX = new PCInputMouseX();
        }

        public void Initialize()
        { }

        public (IUserInputProxy inputHorizontal, IUserInputProxy inputVertical, IUserInputProxy inputMouseX) GetInput()
        {
            (IUserInputProxy inputHorizontal, IUserInputProxy inputVertical, IUserInputProxy inputMouseX) result = (_pcInputHorizontal, _pcInputVertical, _pcInputMouseX);
            return result;
        }
    }
}
