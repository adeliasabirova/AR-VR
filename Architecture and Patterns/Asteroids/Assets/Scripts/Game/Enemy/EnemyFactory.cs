using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public sealed class EnemyFactory : IEnemyFactory
    {
        private readonly EnemyData _data;
        private readonly IPlayer _player;
        public EnemyFactory(EnemyData data, IPlayer player)
        {
            _data = data;
            _player = player;
        }
        public IEnemy CreateEnemy(EnemyType type, Vector3 position, float speed)
        {
            var enemy = _data.GetEnemy(type);
            var enemyGameObject = Object.Instantiate(enemy);
            enemyGameObject.transform.position = position;
            var enemySpeed = enemyGameObject.GetComponent<Enemy>();
            var ability = new List<IAbility>
            {
                new Ability("Inner Fire", 3, DamageType.Magical),
                new Ability("Burning Spear", 6, DamageType.Pure),
                new Ability("Berserker's Blood", 9, DamageType.None),
                new Ability("Life Break", 12, DamageType.Magical),
            };
            enemySpeed.Ability = ability;
            enemySpeed.Speed = speed;
            enemySpeed.Player = _player.GetTransform().GetComponent<IScore>();
            return enemyGameObject;
        }
    }
}
