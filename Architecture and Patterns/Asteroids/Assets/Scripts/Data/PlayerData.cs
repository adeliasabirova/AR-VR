using UnityEngine;

namespace Asteroids
{
    [CreateAssetMenu(fileName = "UnitSettings", menuName = "Data/Unit/UnitSettings")]
    public sealed class PlayerData : ScriptableObject, IUnit
    {
        [SerializeField] private Player PlayerPrefab;
        [SerializeField, Range(0, 10)] private float _speed;
        [SerializeField, Range(0, 10)] private float _acceleration;
        public float Speed => _speed;
        public float Acceleration => _acceleration;
        public Player GetPlayer()
        {
            return PlayerPrefab;
        }
    }
}
