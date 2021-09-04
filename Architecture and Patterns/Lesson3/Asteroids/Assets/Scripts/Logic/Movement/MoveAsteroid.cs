using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    internal sealed class MoveAsteroid : MoveEnemy
    {
        public MoveAsteroid(Transform transform, float speed) : base(transform, speed)
        {
        }

        public override void Move(Vector3 position, float deltaTime)
        {
            base.Move(position, deltaTime);
            Transform.position += Vector3.down * Speed * deltaTime;
        }
    }
}
