using UnityEngine;

namespace SpaceShips
{
    public class Singleton<T> : MonoBehaviour where T: Object
    {
        public static T Instance;

        private void Awake()
        {
            Instance = this as T;
        }
    }
}