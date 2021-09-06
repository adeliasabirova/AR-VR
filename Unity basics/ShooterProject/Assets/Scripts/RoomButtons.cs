using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RoomButtons : MonoBehaviour
{
    public UnityEvent OnCLick;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") )
        {
            OnCLick?.Invoke();
        }
    }
}
