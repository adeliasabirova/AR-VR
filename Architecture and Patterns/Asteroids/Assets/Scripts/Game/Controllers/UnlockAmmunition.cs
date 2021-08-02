namespace Asteroids
{
    public sealed class UnlockAmmunition : IInitialize, IExecute
    {
        private Timer _timer;
        public bool IsUnlock { get; set; }
        
        public UnlockAmmunition(bool isUnlock)
        {
            IsUnlock = isUnlock;
        }

        public void Initialize()
        {
            _timer = new Timer(10.0f);
        }

        public void Execute(float deltaTime)
        {
            if (_timer.Tick(deltaTime))
                IsUnlock = !IsUnlock;
        }
    }
}