using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;

public abstract class FireAction : NetworkBehaviour
{
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private int _startAmmunition = 20;

    [SerializeField] protected float _bulletForce;
    [SerializeField] protected float _bulletTorque;
    [SerializeField] protected Transform _bulletStartPosition;

    protected string countBullet = string.Empty;
    protected Queue<GameObject> bullets = new Queue<GameObject>();
    protected Queue<GameObject> ammunition = new Queue<GameObject>();
    protected bool reloading = false;

    protected virtual void Start()
    {
        for (var i = 0; i < _startAmmunition; i++)
        {
            GameObject bullet;
            if (_bulletPrefab == null)
            {
                bullet = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                bullet.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
            }
            else
            {
                bullet = Instantiate(_bulletPrefab);
            }
            bullet.SetActive(false);
            ammunition.Enqueue(bullet);
        }
    }

    public virtual async void Reloading()
    {
        bullets = await Reload();
    }

    protected virtual void Shooting()
    {
        if (bullets.Count == 0)
        {
            Reloading();
        }
    }

    private async Task<Queue<GameObject>> Reload()
    {
        if (!reloading)
        {
            reloading = true;
            StartCoroutine(ReloadingAnim());
            return await Task.Run(delegate
            {
                var cage = 10;
                if (bullets.Count < cage)
                {
                    Thread.Sleep(3000);
                    var bullets = this.bullets;
                    while (bullets.Count > 0)
                    {
                        ammunition.Enqueue(bullets.Dequeue());
                    }
                    cage = Mathf.Min(cage, ammunition.Count);
                    if (cage > 0)
                    {
                        for (var i = 0; i < cage; i++)
                        {
                            var sphere = ammunition.Dequeue();
                            bullets.Enqueue(sphere);
                        }
                    }
                }
                reloading = false;
                return bullets;
            });
        }
        else
        {
            return bullets;
        }
    }

    private IEnumerator ReloadingAnim()
    {
        while (reloading)
        {
            RayShooter.BulletCount = " | ";
            yield return new WaitForSeconds(0.01f);
            RayShooter.BulletCount = @" \ ";
            yield return new WaitForSeconds(0.01f);
            RayShooter.BulletCount = "---";
            yield return new WaitForSeconds(0.01f);
            RayShooter.BulletCount = " / ";
            yield return new WaitForSeconds(0.01f);
        }
        RayShooter.BulletCount = bullets.Count.ToString();
        yield return null;
    }

}

