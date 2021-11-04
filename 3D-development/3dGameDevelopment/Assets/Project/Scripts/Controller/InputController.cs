namespace Project
{
    internal sealed class InputController : IExecute
    {
        private readonly IUserInputProxy _horizontal;
        private readonly IUserInputProxy _vertical;

        public InputController((IUserInputProxy horizontal, IUserInputProxy vertical) input)
        {
            _horizontal = input.horizontal;
            _vertical = input.vertical;
        }

        public void Execute(float deltaTime)
        {
            _horizontal.GetAxis();
            _vertical.GetAxis();
        }
    }
}
