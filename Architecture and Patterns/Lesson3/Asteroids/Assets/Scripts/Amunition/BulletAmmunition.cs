using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    internal sealed class BulletAmmunition : Ammunition
    {
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