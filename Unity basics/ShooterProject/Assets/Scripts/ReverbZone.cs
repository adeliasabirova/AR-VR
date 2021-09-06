using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReverbZone : MonoBehaviour
{
    private AudioReverbZone _reverbZone;

    private void Awake()
    {
        _reverbZone = GetComponent<AudioReverbZone>();
    }

    private void Start()
    {
        _reverbZone.enabled = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _reverbZone.enabled = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _reverbZone.enabled = false;
        }
    }
}

