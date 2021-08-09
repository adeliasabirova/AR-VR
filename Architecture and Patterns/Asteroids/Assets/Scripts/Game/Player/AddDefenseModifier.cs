namespace Asteroids
{
    internal sealed class AddDefenseModifier : PlayerModifier
    {
        private readonly int _maxDefense;

        public AddDefenseModifier(IPlayer player, int maxDefense)
            : base(player)
        {
            _maxDefense = maxDefense;
        }

        public override void Handle()
        {
            if (_player.GetTransform().GetComponent<Player>().Defense <= _maxDefense)
            {
                _player.GetTransform().GetComponent<Player>().Defense++;
            }

            base.Handle();
        }

    }

}

