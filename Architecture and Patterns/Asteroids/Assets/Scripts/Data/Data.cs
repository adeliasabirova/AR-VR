using System.Collections;
using System.IO;
using System.Linq;
using UnityEngine;

namespace Asteroids
{

    [CreateAssetMenu(fileName ="Data", menuName = "Data/Data")]
    public sealed class Data : ScriptableObject
    {
        [SerializeField] private string _playerDataPath;
        [SerializeField] private string _enemiesDataPath;
        [SerializeField] private string _bulletDataPath;
        private PlayerData _player;
        private EnemyData _enemies;
        private BulletData _bullet;
        public PlayerData Player
        {
            get
            {
                if (_player == null)
                {
                    _player = Load<PlayerData>("Data/" + _playerDataPath);
                }
                return _player;
            }
        }

        public EnemyData Enemies
        {
            get
            {
                if(_enemies == null)
                {
                    _enemies = Load<EnemyData>("Data/" + _enemiesDataPath);
                }
                return _enemies;
            }
        }

        public BulletData Bullet
        {
            get
            {
                if(_bullet == null)
                {
                    _bullet = Load<BulletData>("Data/" + _bulletDataPath);
                }
                return _bullet;
            }
        }

        private T Load<T>(string resourcesPath) where T : Object =>
           Resources.Load<T>(Path.ChangeExtension(resourcesPath, null));
    }
}
