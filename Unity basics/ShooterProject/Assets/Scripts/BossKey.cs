using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossKey : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerArmor>().TakeBossKeys();
            Destroy(gameObject);
        }
    }
}
