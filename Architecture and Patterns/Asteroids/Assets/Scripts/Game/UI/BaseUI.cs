using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    internal abstract class BaseUI : MonoBehaviour
    {
        public abstract void Execute(Dictionary<string, string> list);
        public abstract void Cancel();
    }
}