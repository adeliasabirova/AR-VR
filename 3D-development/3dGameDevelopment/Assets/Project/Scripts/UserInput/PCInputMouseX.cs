using System;
using UnityEngine;

namespace Project
{
    public sealed class PCInputMouseX : IUserInputProxy
    {
        public event Action<float> AxisOnChange = delegate (float f) { };

        public void GetAxis()
        {
            AxisOnChange.Invoke(Input.GetAxis(InputManager.MOUSE_X));
        }
    }
}