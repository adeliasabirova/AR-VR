using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Asteroids
{
    [CreateAssetMenu(fileName ="EnemySettings", menuName ="Data/Unit/EnemySettings")]
    public sealed class EnemyData : ScriptableObject
    {
        [Serializable]
        private struct EnemyInfo
        {
            public EnemyType Type;
            public Enemy EnemyPrefab;
        }
        [SerializeField] private List<EnemyInfo> _enemyInfos;

        public Enemy GetEnemy(EnemyType type)
        {
            var enemyInfo = _enemyInfos.First(info => info.Type == type);
            return enemyInfo.EnemyPrefab;
        }

    }
}
