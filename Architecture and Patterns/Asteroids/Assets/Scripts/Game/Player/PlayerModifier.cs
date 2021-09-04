namespace Asteroids
{
    internal class PlayerModifier
    {
        protected IPlayer _player;
        protected PlayerModifier Next;

        public PlayerModifier(IPlayer player)
        {
            _player = player;
        }

        public void Add(PlayerModifier cm)
        {
            if(Next != null)
            {
                Next.Add(cm);
            }
            else
            {
                Next = cm;
            }
        }
        public virtual void Handle() => Next?.Handle();
    }

}

