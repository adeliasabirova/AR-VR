namespace Project
{
    internal sealed class InputController : IExecute
    {
        private readonly IUserInputProxy _horizontal;
        private readonly IUserInputProxy _vertical;
        private readonly IUserInputProxy _mouseX;

        public InputController((IUserInputProxy horizontal, IUserInputProxy vertical, IUserInputProxy mouseX) input)
        {
            _horizontal = input.horizontal;
            _vertical = input.vertical;
            _mouseX = input.mouseX;
        }

        public void Execute(float deltaTime)
        {
            _horizontal.GetAxis();
            _vertical.GetAxis();
            _mouseX.GetAxis();
        }
    }
}
