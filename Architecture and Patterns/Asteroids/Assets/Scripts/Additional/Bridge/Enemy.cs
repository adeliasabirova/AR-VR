using UnityEngine;

namespace Asteroids.Additional
{
    public sealed class Enemy
    {
        private readonly IAttack _attack;
        private readonly IMove _move;
        private Health _health;
        public Enemy(IAttack attack, IMove move)
        {
            _attack = attack;
            _move = move;
        }

        public Enemy(IAttack attack, IMove move, Health health) : this(attack, move)
        {
            _health = health;
        }

        public void Attack(float deltaTime)
        {
            _attack.Attack(deltaTime);
        }
        public void Move(float deltaTime)
        {
            _move.Move(deltaTime);
        }
    }
}