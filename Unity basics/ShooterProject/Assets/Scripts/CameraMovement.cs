using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform player;
    public float smoothSpeed = 2f;
    public float speedRotation = 3f;

    public Vector3 offset;
    
    private void LateUpdate()
    {
        offset = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * speedRotation * Time.deltaTime, Vector3.up) * offset;
        Vector3 desiredposition = player.position + offset;
        Vector3 smoothedposition = Vector3.Lerp(transform.position, desiredposition, smoothSpeed * Time.deltaTime);
        transform.position = smoothedposition;
        transform.LookAt(player.GetChild(0).GetChild(0).position);
    }
}
