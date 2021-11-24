using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Bullet : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        var damage = other.TryGetComponent<IDamage>(out var component);
        if (damage)
        {
            component.TakeDamage(10);
        }
        gameObject.SetActive(false);
    }
}
