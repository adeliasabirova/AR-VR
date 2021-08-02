using UnityEngine;

namespace Asteroids.Additional
{
    public sealed class InfantryFactory : IFactory
    {
        public Enemy CreateFactory(EnemyInfo info, Vector3 position)
        {
            if (info.Info.UnitType.Equals(UnitType.infantry))
            {
                var prefab = Object.Instantiate(Resources.Load<GameObject>("Additional/Infantry"));
                prefab.transform.position = position;
                var enemy = new Enemy(new FlatteringAttack(prefab.transform, info.SpeedAttack), new Infantry(prefab.transform, info.Speed), info.Info.Health);
                return enemy;
            }
            else
                return null;
        }
        
    }
}