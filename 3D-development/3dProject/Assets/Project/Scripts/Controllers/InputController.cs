namespace Game
{
    internal sealed class InputController : IExecute
    {
        private readonly IUserInputProxy _horizontal;
        private readonly IUserInputProxy _vertical;
        private readonly IUserInputProxy _mouseX;
        private readonly IUserInputProxy _mouseY;
        private readonly IUserButtonInputProxy _jump;

        public InputController((IUserInputProxy horizontal, IUserInputProxy vertical, IUserInputProxy mouseX, IUserInputProxy mouseY, IUserButtonInputProxy jump) input)
        {
            _horizontal = input.horizontal;
            _vertical = input.vertical;
            _mouseX = input.mouseX;
            _mouseY = input.mouseY;
            _jump = input.jump;
        }

        public void Execute(float deltaTime)
        {
            _horizontal.GetAxis();
            _vertical.GetAxis();
            _mouseX.GetAxis();
            _mouseY.GetAxis();
            _jump.GetButtonDown();
        }
    }
}
