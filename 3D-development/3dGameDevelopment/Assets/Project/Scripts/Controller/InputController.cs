﻿namespace Project
{
    internal sealed class InputController : IExecute
    {
        private readonly IUserInputProxy _horizontal;
        private readonly IUserInputProxy _vertical;
        private readonly IUserInputProxy _mouseX;
        private readonly IUserButtonInputProxy _jump;

        public InputController((IUserInputProxy horizontal, IUserInputProxy vertical, IUserInputProxy mouseX, IUserButtonInputProxy jump) input)
        {
            _horizontal = input.horizontal;
            _vertical = input.vertical;
            _mouseX = input.mouseX;
            _jump = input.jump;
        }

        public void Execute(float deltaTime)
        {
            _horizontal.GetAxis();
            _vertical.GetAxis();
            _mouseX.GetAxis();
            _jump.GetButtonDown();
        }
    }
}
