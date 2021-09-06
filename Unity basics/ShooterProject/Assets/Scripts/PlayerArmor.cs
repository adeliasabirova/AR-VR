using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerArmor : MonoBehaviour
{
    [SerializeField] private GameObject _bombPref;
    [SerializeField] private Transform _bombStartPosition;

    [SerializeField] private GameObject _bulletPref;
    [SerializeField] private Transform _bulletStartPosition;

    [SerializeField] private BulletCreation bulletCreation;

    KeyFirstDoor _keyFirstDoor;
    KeyBoss _keyBoss;

    private float _force = 200f;
    private float _maxReloadedTime = 2;

    public int CurrentBullets { get; private set; }
    public int MaxBullets { get; private set; }
    public bool Reloaded { get; private set; }

    public bool IsKeyTaken => _keyFirstDoor.IsKeyTaken;
    public bool IsBossKeyTaken => _keyBoss.IsBossKeysTaken;

    private void Awake()
    {
        _keyFirstDoor = new KeyFirstDoor();
        _keyBoss = new KeyBoss();
    }

    private void Start()
    {
        CurrentBullets = 14;
        MaxBullets = 50;
    }

    public void TakeKey()
    {
        _keyFirstDoor.TakeKey();
    }
    public void TakeBossKeys()
    {
        _keyBoss.TakeKey();
    }

    public void CreateBomb()
    {
        var bomb = Instantiate(_bombPref, _bombStartPosition.position, Quaternion.identity).GetComponent<Bomb>();
        GetComponent<Animator>().SetBool("PutBomb", false);
    }

    public void CreateBullet()
    {
        if (CurrentBullets > 0)
        {
            bulletCreation.CreateBullet(_bulletStartPosition.position, _bulletPref, transform.rotation, transform.forward * _force, Random.insideUnitSphere * 10);
            CurrentBullets--;
            Reloaded = false;
            Invoke("Reload", _maxReloadedTime);
        }
    }
    private void Reload()
    {
        Reloaded = true;
        Animator animator = GetComponent<Animator>();
        animator.SetBool("Attack", false);
    }

    public void TakeBullets(int bullets)
    {
        CurrentBullets += bullets;
    }
}
