using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLifes : MonoBehaviour, ITakeDamage, ITakeMedicine
{

    private int _maxHP = 100;
    private int _currentHP;

    public int MaxHP => _maxHP;
    public int CurrentHP => _currentHP;
    ParticleSystem _particleSystem;


    private void Awake()
    {
        _currentHP = _maxHP;

        _particleSystem = GetComponent<ParticleSystem>();
    }
    
    public void TakeDamage(int damage)
    {
        _particleSystem.Play();
        _currentHP -= damage;
        if (_currentHP <= 0)
        {
            Animator animator = GetComponent<Animator>();
            animator.SetTrigger("Death");
        }

    }
    public void TakeMedicine(int medicine)
    {
        _currentHP = Mathf.Clamp(_currentHP + medicine, 0, _maxHP);
    }
}
