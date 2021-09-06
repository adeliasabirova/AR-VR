using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float _speed = 3;
    private Animator _animator;
    MovePlayer movePlayer;    
    AudioSource _audioSource;
    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();
        string mute = PlayerPrefs.GetString("MuteSound");
        if (mute == "True")
            _audioSource.mute = true;
        else
            _audioSource.mute = false;        
    }

    private void Start()
    {
        movePlayer = new MovePlayer();
    }

    void Update()
    {
        movePlayer.MoveTransform(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), _speed, Time.deltaTime);

        if (movePlayer.Speed != Vector3.zero)
        {
            if (!_audioSource.isPlaying)
                _audioSource.Play();
            _animator.SetBool("Walk", true);
        }
        else
        {
            _audioSource.Stop();
            _animator.SetBool("Walk", false);
        }

        transform.Translate(movePlayer.Speed);

    }
}
