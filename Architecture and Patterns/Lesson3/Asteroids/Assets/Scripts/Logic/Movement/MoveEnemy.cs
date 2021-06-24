using UnityEngine;

namespace Asteroids
{
    internal class MoveEnemy : IMoveEnemy
    {
        protected Transform Transform { get; set; }
        protected Vector3 MoveVector { get; set; }

        public MoveEnemy(Transform transform, float speed)
        {
            Transform = transform;
            Speed = speed;
        }

        public float Speed { get; private set; }

        public virtual void Move(Vector3 position, float deltaTime) { }
    }
}
