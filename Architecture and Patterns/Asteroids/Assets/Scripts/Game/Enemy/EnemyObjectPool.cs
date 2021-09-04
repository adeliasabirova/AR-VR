using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public sealed class EnemyObjectPool : IEnemyObjectPool
    {
        private readonly GameObject _prefab;
        private int _currentID;
        private int _maxID;
        private readonly IPlayer _player;

        public EnemyObjectPool(GameObject prefab, int maxID, Camera camera, IPlayer player)
        {
            _prefab = prefab;
            _currentID = 0;
            _maxID = maxID;
            _player = player;
        }

        public IEnemy CreateEnemy(Vector3 position, float speed)
        {
            if (_currentID == _maxID) _currentID = 0;
            var enemyGameObject = ServiceLocator.Resolve<IViewService>().Create(_currentID, _prefab, true);
            var enemy = enemyGameObject.GetComponent<Asteroid>();
            enemy.Initiate(enemyGameObject, _currentID);
            enemy.transform.position = position;
            enemy.Speed = speed;
            var ability = new List<IAbility>
            {
                new Ability("Inner Fire", 3, DamageType.Magical),
                new Ability("Burning Spear", 6, DamageType.Pure),
                new Ability("Berserker's Blood", 9, DamageType.None),
                new Ability("Life Break", 12, DamageType.Magical),
            };
            enemy.Ability = ability;
            enemy.Player = _player.GetTransform().GetComponent<IScore>();
            _currentID += 1;
            return enemy;
        }
    }
}