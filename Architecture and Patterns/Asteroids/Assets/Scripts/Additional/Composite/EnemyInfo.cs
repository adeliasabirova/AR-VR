namespace Asteroids.Additional
{
    public struct EnemyInfo
    {
        private UnitInfo _info;
        private float _speed;
        private float _speedAttack;

        public EnemyInfo(UnitInfo info, float speed, float speedAttack)
        {
            _info = info;
            _speed = speed;
            _speedAttack = speedAttack;
        }

        public UnitInfo Info => _info;
        public float Speed => _speed;
        public float SpeedAttack => _speedAttack;
    }
}