using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Bullet : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        //var damage = other.TryGetComponent<PlayerCharacter>(out var component);
        
        gameObject.SetActive(false);
    }
}
