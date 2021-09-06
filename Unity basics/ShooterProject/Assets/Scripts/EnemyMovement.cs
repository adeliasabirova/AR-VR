using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    private Transform[] _wayPoints;
    int m_CurrentWaypointIndex;
    public Transform[] WayPoints { get => _wayPoints; set => _wayPoints = value; }

    private AudioSource _audioSource;
    public NavMeshAgent navMeshAgent;

    [SerializeField] Observer _observer;
    private Animator _animator;
    private bool _isAttacked = false;

    [SerializeField] EnemyLifes enemyLifes;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();
        string mute = PlayerPrefs.GetString("MuteSound");
        if (mute == "True")
            _audioSource.mute = true;
        else
            _audioSource.mute = false;
    }

    private void Start()
    {
        navMeshAgent.SetDestination(_wayPoints[0].position);
    }

    private void Update()
    {
        if (_observer.IsPlayerObserved)
        {
            if (!_isAttacked)
            {
                _isAttacked = true;
                _animator.SetBool("Attack", true);
            }
            navMeshAgent.SetDestination(_observer.PlayerPosition.position);
        }
        else if (navMeshAgent.remainingDistance < navMeshAgent.stoppingDistance)
        {
            if (_isAttacked)
            {
                _isAttacked = false;
                _animator.SetBool("Attack", false);
            }
            m_CurrentWaypointIndex = (m_CurrentWaypointIndex + 1) % _wayPoints.Length;
            navMeshAgent.SetDestination(_wayPoints[m_CurrentWaypointIndex].position);
            
        }
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") && enemyLifes.IsAlive)
        {
            collision.gameObject.GetComponent<ITakeDamage>().TakeDamage(5);
        }
    }

}
