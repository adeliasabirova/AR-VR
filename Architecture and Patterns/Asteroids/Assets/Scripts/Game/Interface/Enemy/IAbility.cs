﻿namespace Asteroids
{
    public interface IAbility
    {
        string Name { get; }
        int Damage { get; }
        DamageType DamageType { get; }
    }
}
