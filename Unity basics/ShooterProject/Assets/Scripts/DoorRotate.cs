using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorRotate : MonoBehaviour
{
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
    void Update()
    {
        transform.Rotate(Vector3.up * 20 * Time.deltaTime);
    }
}
