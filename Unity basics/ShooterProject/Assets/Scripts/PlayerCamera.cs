using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    Transform mainCamera;

    private void Awake()
    {
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera").transform;
    }

    private void Update()
    {
        float CamY = mainCamera.transform.eulerAngles.y;
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, CamY, transform.eulerAngles.z);
    }
}
