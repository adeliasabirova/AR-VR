using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    [Serializable]
    public abstract class Enemy : MonoBehaviour
    {
        private Health _health;
        
        public Health Health
        {
            get
            {
                return _health;
            }
            protected set => _health = value;
        }

    }
}
