using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public abstract class BaseUI : MonoBehaviour
    {
        public abstract void Execute(Dictionary<string, string> dictionary);
        public abstract void Cancel();
    }
}