using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public Transform[] _spawnPoints;
    public GameObject _enemyPref;

    private void Start()
    {
        SpawnNewEnemy();
    }

    private void SpawnNewEnemy()
    {
        foreach (var point in _spawnPoints)
        {
            Transform[] wayPoints = new Transform[point.childCount];
            for(int i = 0; i< point.childCount; i++)
            {
                wayPoints[i] = point.GetChild(i).transform;
            }
            var enemy = Instantiate(_enemyPref, point.transform.position, Quaternion.identity);
            enemy.GetComponent<EnemyMovement>().WayPoints = wayPoints;
        }
    }
}
