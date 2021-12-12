using System.Collections.Generic;
using UnityEngine;

namespace Project
{
    internal sealed class EnemyInitalization : IInitialize
    {
        private readonly EnemyData _enemyData;
        private List<Transform> _enemies;
        private readonly List<Vector3> _positions;

        public EnemyInitalization(EnemyData enemyData)
        {
            _enemyData = enemyData;
            _positions = _enemyData.Positions;
            _enemies = new List<Transform>();
        }
        public void Initialize()
        {
            foreach(var position in _positions)
            {
                var enemy = Object.Instantiate(_enemyData.Enemy);
                enemy.position = position;
                _enemies.Add(enemy);
            }
        }

        public IEnumerable<Transform> GetEnemies()
        {
            foreach (var enemy in _enemies)
            {
                yield return enemy;
            }
        }
    }
}
