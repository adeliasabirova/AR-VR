using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Asteroids
{
    internal sealed class EnemuInitialization : IInitialize, IExecute
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

        public EnemuInitialization(IEnemyFactory enemyFactory, IEnemyObjectPool enemyObjectPool, EnemyData data, Camera camera, int capacityEnemy)
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

        public void Execute(float deltaTime)
        {
            if (_cometTimer.Tick(deltaTime))
            {
                var enemy = _enemyFactory.CreateEnemy(EnemyType.Comet, new Vector3(Random.Range(-5f, 1f) + _camera.transform.position.x, 5f + _camera.transform.position.y, 0f), Random.Range(5.0f, 10.0f));
                _enemyMove.AddUnit(enemy);
                _enemies.Add(enemy);
            }
            if (_enemyShipTimer.Tick(deltaTime))
            {
                var enemy = _enemyFactory.CreateEnemy(EnemyType.EnemyShip, new Vector3(Random.Range(-5f, 1f) + _camera.transform.position.x, Random.Range(-5f, 1f) + +_camera.transform.position.y, 0f), Random.Range(2.0f, 6.0f));
                _enemyMove.AddUnit(enemy);
                _enemies.Add(enemy);
            }
            if (_asteroidTimer.Tick(deltaTime))
            {
                var enemy = _enemyObjectPool.CreateEnemy(new Vector3(Random.Range(-5f, 5f) + _camera.transform.position.x, 5f + _camera.transform.position.y, 0f), Random.Range(5.0f, 6.0f));
                _enemyMove.AddUnit(enemy);
                _enemies.Add(enemy);
            }
        }
    }
}