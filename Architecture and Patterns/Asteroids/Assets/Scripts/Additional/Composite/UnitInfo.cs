using System;

namespace Asteroids.Additional
{
    [Serializable]
    public class UnitInfoStrings {
        public string type;
        public string health;
        public string UnitType => type;
        public string Health => health;
    }

    public class UnitInfo
    {
        private UnitType _type;
        private Health _health;

        public UnitInfo(UnitType type, Health health)
        {
            _type = type;
            _health = health;
        }

        public UnitType UnitType => _type;
        public Health Health => _health;
    }
}