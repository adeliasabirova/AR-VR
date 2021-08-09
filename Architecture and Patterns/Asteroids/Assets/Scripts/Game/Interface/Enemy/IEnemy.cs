using System;
using System.Collections;
using System.Collections.Generic;

namespace Asteroids
{
    public interface IEnemy : IMoveEnemy
    {
        event Action<int> OnTriggerEnterChange;
        void OnTriggerEvent();
        int GetInstanceIDEnemy();
        IAbility this[int index] { get; }
        int NumberOfAbilities { get; }
        int MaxDamage { get; }
        IEnumerable<IAbility> GetAbility();
        IEnumerator GetEnumerator();
        IEnumerable<IAbility> GetAbility(DamageType index);

    }
}