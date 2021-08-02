using UnityEngine;

namespace Asteroids.Additional
{
    public sealed class MagFactory : IFactory
    {
        public Enemy CreateFactory(EnemyInfo info, Vector3 position)
        {
            if (info.Info.UnitType.Equals(UnitType.mag))
            {
                var prefab = Object.Instantiate(Resources.Load<GameObject>("Additional/Mag"));
                prefab.transform.position = position;
                var enemy = new Enemy(new MagicalAttack(prefab.transform, info.SpeedAttack), new Mag(prefab.transform, info.Speed), info.Info.Health);
                return enemy;
            }
            else
                return null;
        }
    }
}