using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    internal sealed class InputController
    {
        private readonly IInputController _keyShift;
        private readonly IInputController _keyButton;

        public InputController(IInputController keyShift, IInputController keyButton)
        {
            _keyShift = keyShift;
            _keyButton = keyButton;
        }

        public bool IsKeyShiftDown => _keyShift.DownKeyReceived();
        public bool IsKeyShiftUp => _keyShift.UpKeyReceived();
        public bool IsKeyButtonDown => _keyButton.DownKeyReceived();
        public bool IsKeyButtonUp => _keyButton.UpKeyReceived();
    }
}
