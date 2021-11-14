using UnityEngine;

namespace Project
{
    internal sealed class MovementTranslation : IMoveTranslation
    {
        public Vector3 Speed { get; private set; }

        public void Move(float directionX, float directionZ, float speed, float deltaTime)
        {
            Vector3 direction = new Vector3(directionX, 0, directionZ);
            Speed = direction * speed * deltaTime;
        }
    }
}