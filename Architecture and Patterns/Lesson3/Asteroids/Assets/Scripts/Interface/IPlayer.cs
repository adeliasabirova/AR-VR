using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public interface IPlayer
    {
        void HPChanged(int hp);
    }
}