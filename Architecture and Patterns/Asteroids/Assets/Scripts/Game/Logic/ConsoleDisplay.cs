using UnityEngine;

namespace Asteroids
{
    public sealed class ConsoleDisplay : IDealingCreate
    {
        public void Visit(IEnemy enemy, InfoCreation info)
        {
            Debug.Log($"{enemy} is created at {info.Position}");
        }

        public void Visit(IBullet bullet, InfoCreation info)
        {
            Debug.Log($"{bullet} is created at {info.Position}");
        }
    }
}