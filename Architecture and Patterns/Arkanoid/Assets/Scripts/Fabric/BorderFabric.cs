using UnityEngine;

namespace Arkanoid
{
    internal sealed class BorderFabric : IFabricGameObject
    {
        public void Create(Vector3 position, Quaternion rotation, string path)
        {
            Object.Instantiate(Resources.Load<GameObject>(path), position, rotation);
        }
    }
}