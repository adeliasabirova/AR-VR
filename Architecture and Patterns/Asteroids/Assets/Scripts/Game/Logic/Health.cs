using System;

namespace Asteroids
{
    [Serializable]
    public sealed class Health
    {
        public Health(float maxHP, float currentHP)
        {
            MaxHP = maxHP;
            CurrentHP = currentHP;
        }

        public float MaxHP { get; }
        public float CurrentHP { get; private set; }

        public void ChangeCurrentHealth(float hp)
        {
            CurrentHP -= hp;
        }
    }
}
