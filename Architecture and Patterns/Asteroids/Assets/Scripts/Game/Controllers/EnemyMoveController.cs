using System;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public sealed class EnemyMoveController : IExecute, ICleanup
    {
        private readonly IMoveEnemy _move;
        private CompositeMove _enemy;
        private readonly Vector3 _targetPosition;
        private readonly IEnumerable<IEnemy> _getEnemies;
        private List<IEnemy> _enemies;

        public EnemyMoveController(IMoveEnemy move, IEnumerable<IEnemy> getEnemies, List<IEnemy> enemies, CompositeMove enemy, Vector3 targetPosition)
        {
            _move = move;
            _enemy = enemy;
            _targetPosition = targetPosition;
            _getEnemies = getEnemies;
            _enemies = enemies;
        }

        public void Execute(float deltaTime)
        {
            foreach (var enemy in _getEnemies)
            {
                enemy.OnTriggerEnterChange += EnemyOnOnTriggerEnterChange;
            }

            _move.Move(_targetPosition, deltaTime);
        }


        private void EnemyOnOnTriggerEnterChange(int obj)
        {
            List<IEnemy> enemyToRemove = new List<IEnemy>();
            foreach(var enemy in _getEnemies)
            {
                if (enemy.GetInstanceIDEnemy() == obj)
                {
                    _enemy.RemoveUnit(enemy);
                    enemyToRemove.Add(enemy);
                }

            }

            foreach (var enemy in enemyToRemove)
            {
                enemy.OnTriggerEnterChange -= EnemyOnOnTriggerEnterChange;
                _enemies.Remove(enemy);
                enemy.OnTriggerEvent();                
            }

            enemyToRemove.Clear();
        }

        public void Cleanup()
        {
            foreach (var enemy in _getEnemies)
            {
                enemy.OnTriggerEnterChange -= EnemyOnOnTriggerEnterChange;
            }
        }
    }
}