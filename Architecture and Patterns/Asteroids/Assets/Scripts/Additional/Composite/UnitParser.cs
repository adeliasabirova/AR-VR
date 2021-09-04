using System.Collections.Generic;
using System.IO;

namespace Asteroids.Additional
{

    internal sealed class UnitParser
    {
        private List<EnemyInfo> _enemyInfos;
        private UnitInfoStrings[] _unitInfosStrings;

        private void LoadJson()
        {
            using (StreamReader r = new StreamReader("..\\Asteroids\\Assets\\Scripts\\Additional\\Composite\\UnitDescription.json"))
            {
                string json = r.ReadToEnd();
                _unitInfosStrings = JsonHelper.FromJson<UnitInfoStrings>(json);
            }
        }

        private List<UnitInfo> ToUnitInfo()
        {
            List<UnitInfo> unitInfos = new List<UnitInfo>();
            foreach (var unitInfo in _unitInfosStrings)
            {
                if (unitInfo.UnitType.Equals("mag"))
                    unitInfos.Add(new UnitInfo(UnitType.mag, new Health(float.Parse(unitInfo.Health), float.Parse(unitInfo.Health))));
                else if(unitInfo.UnitType.Equals("infantry"))
                    unitInfos.Add(new UnitInfo(UnitType.infantry, new Health(float.Parse(unitInfo.Health), float.Parse(unitInfo.Health))));
            }
            return unitInfos;
        }
        public UnitParser(float speed, float speedAttack)
        {
            _enemyInfos = new List<EnemyInfo>();
            LoadJson();
            var unitInfos = ToUnitInfo();
            foreach(var unitInfo in unitInfos)
            {
                _enemyInfos.Add(new EnemyInfo(unitInfo, speed, speedAttack));
            }
        }

        public List<EnemyInfo> GetEnemyInfos()
        {
            return _enemyInfos;
        }
    }
}