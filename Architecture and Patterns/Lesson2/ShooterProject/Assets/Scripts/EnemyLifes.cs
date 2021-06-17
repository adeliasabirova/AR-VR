using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyLifes : MonoBehaviour, ITakeDamage
{
    private int _maxHP = 100;
    private int _currentHP;
    public bool IsAlive { get; private set; }
    public int MaxHP => _maxHP;
    public int CurrentHP => _currentHP;

    [SerializeField] private MeshRenderer _meshRenderer;
    [SerializeField] private Color _dethcolor;

    ParticleSystem _particleSystem;

    private void Awake()
    {
        _currentHP = _maxHP;
        IsAlive = true;
        _particleSystem = GetComponent<ParticleSystem>();
    }

    public void TakeDamage(int damage)
    {
        _particleSystem.Play();
        _currentHP -= damage;
        if (_currentHP <= 0 && IsAlive)
        {
            var main = _particleSystem.main;
            main.loop = true;
            StartCoroutine(DeathAnimation());
            GetComponent<Animator>().SetTrigger("Death");
            IsAlive = false;
        }
    }

    IEnumerator DeathAnimation()
    {
        while (_meshRenderer.material.color != _dethcolor)
        {
            _meshRenderer.material.color = Color.Lerp(_meshRenderer.material.color, _dethcolor, 0.01f);
            yield return null;
        }

        yield return new WaitForSeconds(3);
        Destroy(gameObject);
    }
}
