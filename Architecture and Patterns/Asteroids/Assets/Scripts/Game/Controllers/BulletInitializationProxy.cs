namespace Asteroids
{
    internal sealed class BulletInitializationProxy : IExecute 
    {
        private readonly BulletInitialization _bulletInitialization;
        private readonly UnlockAmmunition _unlockAmmunition;

        public BulletInitializationProxy(BulletInitialization bulletInitialization, UnlockAmmunition unlockAmmunition)
        {
            _bulletInitialization = bulletInitialization;
            _unlockAmmunition = unlockAmmunition;
        }

        public void Execute(float deltaTime)
        {
            if (_unlockAmmunition.IsUnlock)
            {
                _bulletInitialization.Execute(deltaTime);
            }
        }
    }
}