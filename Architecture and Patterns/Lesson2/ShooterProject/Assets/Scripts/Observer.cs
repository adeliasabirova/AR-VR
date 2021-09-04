using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Observer : MonoBehaviour
{
    public Transform PlayerPosition { get; private set; }
    public bool IsPlayerObserved { get; private set; }

    List<Collider> _triggerList;

    private void Awake()
    {
        _triggerList = new List<Collider>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (!_triggerList.Contains(other) && !other.CompareTag("Player"))
            _triggerList.Add(other);
        
        if (other.CompareTag("Player"))
        {
            IsPlayerObserved = true;
            PlayerPosition = other.transform;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (_triggerList.Contains(other))
            _triggerList.Remove(other);

        if (other.CompareTag("Player"))
        {
            IsPlayerObserved = false;
            PlayerPosition = null;
        }
    }

}
