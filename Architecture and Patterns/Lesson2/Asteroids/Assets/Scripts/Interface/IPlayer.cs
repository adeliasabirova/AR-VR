using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public interface IPlayer
    {
        int CurrentHP { get; }
        void HPChanged(int hp);
    }
}