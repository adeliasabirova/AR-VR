using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public interface IInputController
    {
        bool DownKeyReceived();
        bool UpKeyReceived();
    }
}
