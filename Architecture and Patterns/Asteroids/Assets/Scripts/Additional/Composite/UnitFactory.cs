using System.Collections.Generic;
using UnityEngine;

namespace Asteroids.Additional
{
    internal sealed class UnitFactory : IFactory
    {
        private List<IFactory> _factories = new List<IFactory>();
        public void AddUnit(IFactory factory)
        {
            _factories.Add(factory);
        }
        public void RemoveUnit(IFactory factory)
        {
            _factories.Remove(factory);
        }

        public Enemy CreateFactory(EnemyInfo info, Vector3 position)
        {
            Enemy enemy = null;
            foreach(var factory in _factories)
            {
                Enemy enemyFromFactory =factory.CreateFactory(info, position); 
                if (!(enemyFromFactory is null))
                {
                    enemy = enemyFromFactory;
                }
            }
            return enemy;
        }
        
    }
}