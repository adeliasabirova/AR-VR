using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    internal sealed class BulletAmmunition : Ammunition, IBullet
    {
        public event Action<int> OnTriggerEnterChange;

        public void Activate(IDealingCreate value, Vector3 position)
        {
            value.Visit(this, new InfoCreation(position));
        }

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