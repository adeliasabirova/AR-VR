using UnityEngine;

namespace Arkanoid
{
    internal sealed class BackgroundFabric
    {
        public BackgroundFabric()
        {
            new BorderFabric().Create(new Vector3(-6.47f, -0.1f, 0f), new Quaternion(), "Background/border_left");
            new BorderFabric().Create(new Vector3(6.47f, -0.1f, 0f), new Quaternion(), "Background/border_right");
            new BorderFabric().Create(new Vector3(0.005f, 4.9f, 0f), new Quaternion(), "Background/border_top");
            new BlocksFabric().Create(new Vector3(-5.6f, 1f, 0f), new Quaternion(), "Blocks/block_blue");
            new BlocksFabric().Create(new Vector3(-5.6f, 1.5f, 0f), new Quaternion(), "Blocks/block_yellow");
            new BlocksFabric().Create(new Vector3(-5.6f, 2f, 0f), new Quaternion(), "Blocks/block_pink");
            new BlocksFabric().Create(new Vector3(-5.6f, 2.5f, 0f), new Quaternion(), "Blocks/block_red");
            new BlocksFabric().Create(new Vector3(-5.6f, 3f, 0f), new Quaternion(), "Blocks/block_green");
        }
    }
}