using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    private float _explosionTime = 10;

    private float _force = 350;
    AudioSource _audioSource;
    ParticleSystem _particleSystem;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        string mute = PlayerPrefs.GetString("MuteSound");
        if (mute == "True")
            _audioSource.mute = true;
        else
            _audioSource.mute = false;

        _particleSystem = GetComponent<ParticleSystem>();
    }

    private void Start()
    {
        _particleSystem.Play();
        Invoke("Explosion", _explosionTime);
    }

    private void Explosion()
    {
        var collisions = Physics.OverlapSphere(transform.position, 3);
        foreach (var collidir in collisions)
        {
            if (collidir.CompareTag("Enemy"))
            {
                collidir.GetComponent<ITakeDamage>().TakeDamage(40);
                var rb = collidir.GetComponent<Rigidbody>();
                if (rb != null)
                    rb.AddForce(rb.gameObject.transform.position * _force, ForceMode.Impulse);
            }
            
        }
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<ITakeDamage>().TakeDamage(40);
            _audioSource.Stop();
            Destroy(gameObject);
        }
    }

    

}
