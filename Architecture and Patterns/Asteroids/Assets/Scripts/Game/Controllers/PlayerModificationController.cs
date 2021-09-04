namespace Asteroids
{
    internal sealed class PlayerModificationController : IInitialize, IExecute
    {
        private IPlayer _player;
        private Timer _timer;
        private int _defenseModification;
        private PlayerModifier _root;

        public PlayerModificationController(IPlayer player)
        {
            _player = player;
            _timer = new Timer(10);
        }

        public void Execute(float deltaTime)
        {
            if (_timer.Tick(deltaTime))
            {
                _defenseModification = _player.GetTransform().GetComponent<Player>().Defense;
                _root.Add(new AddDefenseModifier(_player, 10));
                _root.Handle();
            }
        }

        public void Initialize()
        {
            _root = new PlayerModifier(_player);
        }
    }
}