namespace Asteroids
{
    internal sealed class InputInitialization : IInitialize
    {
        private IUserInputProxy _pcInputHorizontal;
        private IUserInputProxy _pcInputVertical;
        private IUserMouseInputProxy _pcInputFire;
        private IUserKeyInputProxy _pcInputShift;

        public InputInitialization()
        {
            _pcInputHorizontal = new PCInputHorizontal();
            _pcInputVertical = new PCInputVertical();
            _pcInputFire = new PCInputFire();
            _pcInputShift = new PCInputShift();
        }

        public void Initialize()
        { }

        public (IUserInputProxy inputHorizontal, IUserInputProxy inputVertical, IUserMouseInputProxy inputFire, IUserKeyInputProxy inputShift) GetInput()
        {
            (IUserInputProxy inputHorizontal, IUserInputProxy inputVertical, IUserMouseInputProxy inputFire, IUserKeyInputProxy inputShift) result = (_pcInputHorizontal, _pcInputVertical, _pcInputFire, _pcInputShift);
            return result;
        }
    }
}