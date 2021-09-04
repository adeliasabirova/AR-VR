using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicInGame : MonoBehaviour
{
    AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        string mute = PlayerPrefs.GetString("MuteMusic");
        if (mute == "True")
            _audioSource.mute = true;
        else
            _audioSource.mute = false;
    }
}
