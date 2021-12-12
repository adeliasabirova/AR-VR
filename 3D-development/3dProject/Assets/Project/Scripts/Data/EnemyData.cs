using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    [CreateAssetMenu(fileName = "EnemyData", menuName = "Data/Unit/EnemyData")]
    public sealed class EnemyData : ScriptableObject
    {
        [SerializeField] private Transform _enemy;
        [SerializeField] private List<Vector3> _positions;
        [SerializeField] private float _scale;

        public Transform Enemy => _enemy;
        public List<Vector3> Positions => _positions;
        public float Scale => _scale;
    }
}