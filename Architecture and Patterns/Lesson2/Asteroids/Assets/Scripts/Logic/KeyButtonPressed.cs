using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    internal sealed class KeyButtonPressed : IInputController
    {
        private readonly string _buttonName;

        public KeyButtonPressed(string buttonName)
        {
            _buttonName = buttonName;
        }

        public bool DownKeyReceived()
        {
            return Input.GetButtonDown(_buttonName);
        }

        public bool UpKeyReceived()
        {
            return Input.GetButtonUp(_buttonName);
        }
    }
}
