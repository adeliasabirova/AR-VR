using UnityEngine;

namespace Game
{
    internal sealed class HealthController: IInitialize, IGUI
    {
        private readonly PlayerBodyData _playerData;
        private float _maxHP;
        private float _currentHP;

        public float MaxHP => _maxHP;
        public float CurrentHP => _currentHP;


        public HealthController(PlayerBodyData playerData)
        {
            _playerData = playerData;
        }

        public void Initialize()
        {
            _maxHP = _playerData.HealthPoints;
            _currentHP = _playerData.HealthPoints;
        }

        public void HealthChange(float healthPoints)
        {
            if (_currentHP - healthPoints > 0)
                _currentHP -= healthPoints;
            else
                _currentHP = 0;
        }

        public void Gui()
        {
            var text = $"Current Health Points: {_currentHP}";
            GUI.TextField(new Rect(10, 10, 200, 30), text);
        }
    }
}
