using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class PlayerPause : MonoBehaviour
{

    [SerializeField] private GameObject pauseMenuUI;
    AudioSource _audioSource;
    Rigidbody playerRigidBody;
    private Animator _animator;

    private bool _isPaused = false;
    private bool _isGround = true;
    private float _force = 5;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        playerRigidBody = GetComponent<Rigidbody>();
        _audioSource = GetComponent<AudioSource>();
    }


    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
            _animator.SetBool("PutBomb", true);

        if (Input.GetMouseButtonDown(0))
            if (!pauseMenuUI.activeSelf)
                _animator.SetBool("Attack", true);

        RaycastHit hit;
        var rayCast = Physics.Raycast(transform.GetChild(0).position, Vector3.down, out hit, 1.5f);

        if (rayCast)
        {
            _isGround = true;
        }
        else
            _isGround = false;

        _animator.SetBool("Jump", !_isGround);

        if (Input.GetKeyDown("space") && _isGround)
        {
            _audioSource.Stop();
            playerRigidBody.AddForce(transform.up * _force, ForceMode.VelocityChange);
        }

        if (Input.GetKey(KeyCode.Space))
        {
            _audioSource.Stop();
            playerRigidBody.AddForce(transform.up * _force, ForceMode.Acceleration);
        }

        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            _isPaused = !_isPaused;
        }

        if (_isPaused)
            SceneManager.LoadScene("PauseMenuScene");

    }
}
