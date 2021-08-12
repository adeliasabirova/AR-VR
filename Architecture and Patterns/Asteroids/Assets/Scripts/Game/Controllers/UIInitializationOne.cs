namespace Asteroids
{
    internal sealed class UIInitializationOne : UIInitialization
    {
        private readonly IPlayer _player;
        private ScoreDisplay _scoreDisplay;

        public UIInitializationOne(BaseUI baseUI, IPlayer player) : base(baseUI)
        {
            _player = player;
            _scoreDisplay = new ScoreDisplay();

            _dict.Add("score", " ");
            _dict.Add("damage", " ");
        }

        public override void Execute(float deltaTime)
        {
            _dict["score"] = _scoreDisplay.Intepretator(_player.GetTransform().GetComponent<Player>().Score);
            _dict["damage"] = _player.GetTransform().GetComponent<Player>().Health.CurrentHP.ToString();
            _baseUI.Execute(_dict);
        }

    }
}
