using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesManager : MonoBehaviour
{
    public GameObject[] Enemies;

    private int _enemiesCount;

    private void OnEnable()
    {
        Actions.OnEnemyKilled += ReduceEnemiesCount;
    }

    private void OnDestroy()
    {
        Actions.OnEnemyKilled -= ReduceEnemiesCount;
    }

    void Start()
    {
        _enemiesCount = Enemies.Length+1;    
    }

    void Update()
    {
        if(_enemiesCount == 0)
        {
            Actions.OnEndGame("Win");
        }
    }

    private void ReduceEnemiesCount(float val) => _enemiesCount--;
}
