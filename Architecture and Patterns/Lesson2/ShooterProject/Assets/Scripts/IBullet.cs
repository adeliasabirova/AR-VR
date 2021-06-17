using UnityEngine;

interface IBullet
{
    void CreateBullet(Vector3 position, GameObject gameobject, Quaternion rotation, Vector3 force, Vector3 torque);
}
