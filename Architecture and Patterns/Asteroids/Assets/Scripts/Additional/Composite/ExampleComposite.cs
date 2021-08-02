using System.Collections.Generic;
using UnityEngine;

namespace Asteroids.Additional
{
    internal sealed class ExampleComposite : MonoBehaviour
    {
        [SerializeField]
        private float _speed;
        [SerializeField]
        private float _speedAttack;
        private Timer _timer;
        private bool _isAttack = false;
        private UnitFactory _factories;
        private List<IFactory> _listFactories;
        private List<Enemy> _enemies;

        private void Start()
        {
            _timer = new Timer(4);

            _listFactories = new List<IFactory>();
            _listFactories.Add(new MagFactory());
            _listFactories.Add(new InfantryFactory());

            _factories = new UnitFactory();
            foreach (var factory in _listFactories)
                _factories.AddUnit(factory);

            var unitParser = new UnitParser(_speed, _speedAttack);
            var enemyInfos = unitParser.GetEnemyInfos();

            _enemies = new List<Enemy>();
            foreach (var enemyInfo in enemyInfos) {
                var enemy = _factories.CreateFactory(enemyInfo, new Vector3(Random.Range(-5.0f, 0.0f), Random.Range(0.0f, 4.0f), 0.0f));
                _enemies.Add(enemy);
            }
        }

        private void Move(float deltaTime)
        {
            foreach (var enemy in _enemies)
            {
                enemy.Move(deltaTime);
            }
        }

        private void Attack(float deltaTime)
        {
            foreach (var enemy in _enemies)
            {
                if (_timer.Tick(deltaTime))
                    if (_isAttack == false)
                        _isAttack = true;
                    else
                        _isAttack = false;
                if (_isAttack)
                    enemy.Attack(deltaTime);
            }
        }

        private void Update()
        {
            float deltaTime = Time.deltaTime;
            Move(deltaTime);
            Attack(deltaTime);
        }

        private void OnDestroy()
        {
            foreach (var factory in _listFactories)
                _factories.RemoveUnit(factory);
            _listFactories.Clear();
        }
    }
}