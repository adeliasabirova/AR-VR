using System;
using System.IO;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Galaxy
{
    [CreateAssetMenu(fileName ="Data", menuName ="Data/Data")]
    public sealed class Data : ScriptableObject
    {
        [SerializeField] private string _celestialBodyPath;
        [SerializeField] private int _numberOfIntities;
        private CelestailBodyData _celestailBody;

        public CelestailBodyData CelestailBody
        {
            get
            {
                if(_celestailBody == null)
                {
                    _celestailBody = Load<CelestailBodyData>("Data/" + _celestialBodyPath);
                }
                return _celestailBody;
            }
        }

        public int NumberOfIntities => _numberOfIntities;

        private T Load<T>(string resourcesPath) where T : Object =>
           Resources.Load<T>(Path.ChangeExtension(resourcesPath, null));
    }
}