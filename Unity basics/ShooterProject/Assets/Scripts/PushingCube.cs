using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushingCube : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Rigidbody rb = gameObject.GetComponent<Rigidbody>();
            rb.AddForce(Vector3.forward * 3f);
        }
    }
}
