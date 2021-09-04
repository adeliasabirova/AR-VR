using UnityEngine;

namespace Arkanoid
{
    public interface IFabricGameObject
    {
        void Create(Vector3 position, Quaternion rotation, string path);
    }
}