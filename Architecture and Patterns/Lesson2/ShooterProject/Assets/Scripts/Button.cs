using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Button : MonoBehaviour
{
    [SerializeField] private Transform _door;
    private Animator _doorAnimator;
    private float _maxReloadedTime = 2;
    AudioSource _doorAudioSource;

    private void Awake()
    {
        _doorAnimator = _door.GetComponent<Animator>();
        _doorAudioSource = _door.GetComponent<AudioSource>();
        string mute = PlayerPrefs.GetString("MuteSound");
        if (mute == "True")
            _doorAudioSource.mute = true;
        else
            _doorAudioSource.mute = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && other.GetComponent<PlayerArmor>().IsKeyTaken)
        {
            _doorAnimator.SetBool("Stay", false);
            _doorAnimator.SetBool("Open", true);
            _doorAudioSource.Play();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("BossKey"))
        {
            _door.position = new Vector3(22.445f, 0, 28.353f);
            _doorAnimator.SetBool("Open", false);
            _doorAnimator.SetBool("Close", false);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && other.GetComponent<PlayerArmor>().IsKeyTaken)
        {
            _doorAnimator.SetBool("Open", false);
            _doorAnimator.SetBool("Close", true);
            _doorAudioSource.Play();
            Invoke("Reload", _maxReloadedTime);
        }
    }

    private void Reload()
    {
        _doorAnimator.SetBool("Close", false);
        _doorAnimator.SetBool("Stay", true);
    }

}
