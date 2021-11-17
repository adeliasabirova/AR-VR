using UnityEngine;

namespace Project
{
    [CreateAssetMenu(fileName = "EnemyData", menuName = "Data/Unit/EnemyData")]
    public sealed class EnemyData : ScriptableObject
    {
        [SerializeField] private Transform _enemy;
        [SerializeField] private Vector3 _position;
        [SerializeField] private float _scale;

        public Transform Enemy => _enemy;
        public Vector3 Position => _position;
        public float Scale => _scale;
    }
}