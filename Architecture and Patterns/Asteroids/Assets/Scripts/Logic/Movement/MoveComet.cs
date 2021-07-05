using System;
using UnityEngine;

namespace Asteroids
{
    [Serializable]
    internal sealed class MoveComet : MoveEnemy
    {

        public MoveComet(Transform transform, float speed) : base(transform, speed)
        {
        }

        public override void Move(Vector3 position, float deltaTime)
        {
            base.Move(position, deltaTime);
            Transform.position += new Vector3(1f, -1f, 0) * Speed * deltaTime;
        }
    }
}
