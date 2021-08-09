using System.Collections.Generic;

namespace Asteroids
{
    internal sealed class UIInitialization : IInitialize, IExecute, ICleanup
    {
        private readonly IPlayer _player;
        private readonly BaseUI _baseUI;
        private ScoreDisplay _scoreDisplay;
        private Dictionary<string, string> _dict;

        public UIInitialization(IPlayer player, BaseUI baseUI)
        {
            _player = player;
            _baseUI = baseUI;
            _scoreDisplay = new ScoreDisplay();
            _dict = new Dictionary<string, string>();
            _dict.Add("score", " ");
            _dict.Add("damage", " ");
        }

        public void Cleanup()
        {
            _baseUI.Cancel();
        }

        public void Execute(float deltaTime)
        {
            _dict["score"] = _scoreDisplay.Intepretator(_player.GetTransform().GetComponent<Player>().Score);
            _dict["damage"] = _player.GetTransform().GetComponent<Player>().Health.CurrentHP.ToString();
            _baseUI.Execute(_dict);
        }

        public void Initialize()
        {
            _baseUI.Cancel();
        }
    }
}
