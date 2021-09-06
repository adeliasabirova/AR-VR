using UnityEngine;

interface ILookAt
{
    Quaternion LookAt(Vector3 direction, Vector3 relative, float speed);
}
