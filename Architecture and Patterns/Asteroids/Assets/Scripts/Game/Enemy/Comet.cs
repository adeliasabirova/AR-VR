using System;
using UnityEngine;

namespace Asteroids
{
    [Serializable]
    public sealed class Comet : Enemy
    {
        public override void Move(Vector3 position, float deltaTime)
        {
            base.Move(position, deltaTime);
            transform.position += new Vector3(1f, -1f, 0) * Speed * deltaTime;
        }

        public override void OnTriggerEvent()
        {
            base.OnTriggerEvent();
            Destroy(gameObject);
        }
    }
}

