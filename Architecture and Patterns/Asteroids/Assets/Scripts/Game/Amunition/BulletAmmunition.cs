using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    internal sealed class BulletAmmunition : Ammunition, IBullet
    {
        public event Action<int> OnTriggerEnterChange;

        private void OnBecameInvisible()
        {
            ReturnToPool();
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            
            ReturnToPool();
        }
    }
}