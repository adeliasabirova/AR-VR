using System.Collections.Generic;

namespace Asteroids
{
    internal sealed class UIInitializationTwo : UIInitialization
    {
        private readonly IEnumerable<IEnemy> _getEnemies;
        public UIInitializationTwo(BaseUI baseUI, IEnumerable<IEnemy> getEnemies) : base(baseUI)
        {
            _getEnemies = getEnemies;
            _dict.Add("enemy", "Enemy is destroyed");
        }
        public override void Execute(float deltaTime)
        {
            foreach (var enemy in _getEnemies)
            {
                enemy.OnTriggerEnterChange += EnemyOnOnTriggerEnterChange;
            }
        }
        private void EnemyOnOnTriggerEnterChange(int obj)
        {
            if (obj != 0)
            {
                _baseUI.Cancel();
                _baseUI.Execute(_dict);
            }
        }
    }
}
