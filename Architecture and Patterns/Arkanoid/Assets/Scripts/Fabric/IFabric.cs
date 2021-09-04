using UnityEngine;

namespace Arkanoid
{
    public interface IFabric
    {
        IView Create(Vector3 position, Quaternion rotation);
    }
}