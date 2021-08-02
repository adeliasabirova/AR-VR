using System;
using UnityEngine;

namespace Asteroids
{
    public sealed class PCInputHorizontal : IUserInputProxy
    {
        public event Action<float> AxisOnChange = delegate(float f) { };

        public void GetAxis()
        {
            AxisOnChange.Invoke(Input.GetAxis(InputManager.HORIZONTAL));
        }
    }
}