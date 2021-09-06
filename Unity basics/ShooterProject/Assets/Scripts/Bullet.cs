using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float _startTime;
    AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        string mute = PlayerPrefs.GetString("MuteSound");
        if (mute == "True")
            _audioSource.mute = true;
        else
            _audioSource.mute = false;
    }
    private void Start()
    {
        _audioSource.Play();
        _startTime = Time.time;
    }

    void Update()
    {
        if (Time.time - _startTime > 10)
            Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Enemy") || other.CompareTag("Player"))
        {
            
            other.GetComponent<ITakeDamage>().TakeDamage(10);
        }
        Destroy(gameObject);
    }
}
