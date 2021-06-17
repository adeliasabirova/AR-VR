using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && other.GetComponent<PlayerArmor>().IsBossKeyTaken)
        {
            _audioSource.Stop();
            _particleSystem.Stop();
            GetComponent<Animator>().SetTrigger("Death");

            var enemies = GameObject.FindGameObjectsWithTag("Enemy");
            foreach (var enemy in enemies)
            {
                enemy.GetComponent<ITakeDamage>().TakeDamage(100);
            }

        }
    }
}
