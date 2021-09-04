using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Asteroids
{

    internal sealed class EnemyInitialization : IInitialize, IExecute
    {
        private readonly IEnemyFactory _enemyFactory;
        private readonly IEnemyObjectPool _enemyObjectPool;
        private readonly EnemyData _data;
        private CompositeMove _enemyMove;
        private Camera _camera;
        private Timer _cometTimer;
        private Timer _asteroidTimer;
        private Timer _enemyShipTimer;
        private List<IEnemy> _enemies;

        public EnemyInitialization(IEnemyFactory enemyFactory, IEnemyObjectPool enemyObjectPool, EnemyData data, Camera camera, int capacityEnemy)
        {
            _enemyFactory = enemyFactory;
            _enemyObjectPool = enemyObjectPool;
            _data = data;
            _camera = camera;
            ServiceLocator.SetService<IViewService>(new ViewService(capacityEnemy));
            _enemyMove = new CompositeMove();
            _enemies = new List<IEnemy>();
        }

        public void Initialize()
        {
            _cometTimer = new Timer(5.0f);
            _asteroidTimer = new Timer(0.5f);
            _enemyShipTimer = new Timer(15.0f);
        }

        public CompositeMove GetCompositeMove()
        {
            return _enemyMove;
        }

        public IMoveEnemy GetMoveEnemy()
        {
            return _enemyMove;
        }

        public List<IEnemy> GetListEnemis()
        {
            return _enemies;
        }

        public IEnumerable<IEnemy> GetEnemies()
        {
            foreach (var enemy in _enemies)
            {
                yield return enemy;
            }
        }

        private void EnemyExecution(IEnemy enemy, Vector3 position)
        {
            _enemyMove.AddUnit(enemy);
            _enemies.Add(enemy);
            enemy.Activate(new ConsoleDisplay(), position);
        }
        public void Execute(float deltaTime)
        {
            if (_cometTimer.Tick(deltaTime))
            {
                var position = new Vector3(Random.Range(-5f, 1f) + _camera.transform.position.x, 5f + _camera.transform.position.y, 0f);
                var enemy = _enemyFactory.CreateEnemy(EnemyType.Comet, position, Random.Range(5.0f, 10.0f));
                EnemyExecution(enemy, position);
            }
            if (_enemyShipTimer.Tick(deltaTime))
            {
                var position = new Vector3(Random.Range(-5f, 1f) + _camera.transform.position.x, Random.Range(-5f, 1f) + +_camera.transform.position.y, 0f);
                var enemy = _enemyFactory.CreateEnemy(EnemyType.EnemyShip, position, Random.Range(2.0f, 6.0f));
                EnemyExecution(enemy, position);
            }
            if (_asteroidTimer.Tick(deltaTime))
            {
                var position = new Vector3(Random.Range(-5f, 5f) + _camera.transform.position.x, 5f + _camera.transform.position.y, 0f);
                var enemy = _enemyObjectPool.CreateEnemy(position, Random.Range(5.0f, 6.0f));
                EnemyExecution(enemy, position);
            }
        }
    }
}