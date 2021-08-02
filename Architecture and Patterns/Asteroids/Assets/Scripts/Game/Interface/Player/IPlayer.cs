using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public interface IPlayer
    {
        event Action<int> OnCollisionEnterChange;
        Transform GetTransform();
    }
}