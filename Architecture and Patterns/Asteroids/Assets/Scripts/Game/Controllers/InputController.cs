using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    internal sealed class InputController : IExecute
    {
        private readonly IUserInputProxy _horizontal;
        private readonly IUserInputProxy _vertical;
        private readonly IUserMouseInputProxy _fire;
        private readonly IUserKeyInputProxy _leftShift;

        public InputController((IUserInputProxy horizontal, IUserInputProxy vertical, IUserMouseInputProxy fire, IUserKeyInputProxy leftShift) input)
        {
            _horizontal = input.horizontal;
            _vertical = input.vertical;
            _fire = input.fire;
            _leftShift = input.leftShift;
        }

        public void Execute(float deltaTime)
        {
            _horizontal.GetAxis();
            _vertical.GetAxis();
            _fire.GetButtonDown();
            _fire.GetButtonUp();
            _leftShift.GetKeyDown();
            _leftShift.GetKeyUp();
        }
    }
}
