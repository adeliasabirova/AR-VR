using System.Collections;
using System.Collections.Generic;

namespace Asteroids
{
    public interface IEnemyFactory
    {
        Enemy Create(Health hp);
    }
}