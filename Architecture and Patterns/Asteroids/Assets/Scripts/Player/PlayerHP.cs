using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    internal sealed class PlayerHP : IPlayer
    {
        private readonly float _maxHP = 100.0f;
        private Health _health;
        private GameObject _player;

        public PlayerHP(GameObject player)
        {
            _health = new Health(_maxHP, _maxHP);
            _player = player;
        }

        public void HPChanged(int hp)
        {
            _health.ChangeCurrentHealth(hp);
            if (_health.CurrentHP <= 0)
            {
                GameObject.Destroy(_player);
            }
        }
    }
}
