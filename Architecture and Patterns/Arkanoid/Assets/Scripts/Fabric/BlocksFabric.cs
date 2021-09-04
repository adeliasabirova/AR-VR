using UnityEngine;

namespace Arkanoid
{
    internal sealed class BlocksFabric : IFabricGameObject
    {
        public void Create(Vector3 position, Quaternion rotation, string path)
        {
            for (int i = 0; i < 15; i++)
            {
                var new_position = position + new Vector3(0.8f, 0f, 0f) * i;
                Object.Instantiate(Resources.Load<GameObject>(path), new_position, rotation);
            }
        }
    }
}