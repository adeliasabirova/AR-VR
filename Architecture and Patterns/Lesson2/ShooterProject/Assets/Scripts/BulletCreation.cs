using UnityEngine;

public class BulletCreation : MonoBehaviour, IBullet
{
    public void CreateBullet(Vector3 position, GameObject gameobject, Quaternion rotation, Vector3 force, Vector3 torque)
    {
        var bullet = Instantiate(gameobject, position, rotation).GetComponent<Rigidbody>();
        bullet.AddForce(force);
        bullet.AddTorque(torque);
    }
}
