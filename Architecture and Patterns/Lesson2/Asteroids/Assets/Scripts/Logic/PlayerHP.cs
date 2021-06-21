using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    internal sealed class PlayerHP : IPlayer
    {
        private readonly int _maxHP = 100;
        private GameObject _player;

        public PlayerHP(GameObject player)
        {
            CurrentHP = _maxHP;
            _player = player;
        }

        public int CurrentHP { get; protected set; }

        public void HPChanged(int hp)
        {
            CurrentHP -= hp;
            if (CurrentHP <= _maxHP)
            {
                GameObject.Destroy(_player);
            }
        }
    }
}
