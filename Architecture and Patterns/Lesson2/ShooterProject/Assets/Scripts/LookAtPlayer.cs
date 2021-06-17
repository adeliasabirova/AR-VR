using UnityEngine;

public class LookAtPlayer : ILookAt
{
    public Quaternion LookAt(Vector3 direction, Vector3 relative, float speed)
    {
        Vector3 newDirection = Vector3.RotateTowards(direction, relative, speed, 0f);
        return Quaternion.LookRotation(newDirection);
    }
}
