using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    internal sealed class KeyShiftPressed : IInputController
    {
        public bool DownKeyReceived()
        {
            return Input.GetKeyDown(KeyCode.LeftShift);
        }

        public bool UpKeyReceived()
        {
            return Input.GetKeyUp(KeyCode.LeftShift);
        }
    }
}
