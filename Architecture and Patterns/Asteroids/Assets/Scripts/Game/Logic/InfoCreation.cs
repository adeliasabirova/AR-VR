using UnityEngine;

namespace Asteroids
{
    public struct InfoCreation
    {
        private readonly Vector3 _position;
        public InfoCreation(Vector3 position)
        {
            _position = position;
        }
        public Vector3 Position => _position;
    }
}