

using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public sealed class CompositeMove : IMoveEnemy
    {
        private List<IMoveEnemy> _moves = new List<IMoveEnemy>();

        public float Speed { get; }

        public void AddUnit(IMoveEnemy unit)
        {
            _moves.Add(unit);
        }
        public void RemoveUnit(IMoveEnemy unit)
        {
            _moves.Remove(unit);
        }
        public void Move(Vector3 position, float deltaTime)
        {
            for (var i = 0; i < _moves.Count; i++)
                _moves[i].Move(position, deltaTime);
        }
    }
}
