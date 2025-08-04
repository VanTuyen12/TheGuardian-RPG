using System;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawning : EnemyManagerAbstract
{
    [SerializeField] protected float spawnSpeed = 2f;
    [SerializeField] protected int maxSpawn = 20;
    [SerializeField]protected List<EnemyCtrl> spawnedEnemies = new();
    protected override void Start()
    {
        base.Start();
        Invoke(nameof(Spawning), spawnSpeed);
    }

    protected virtual void FixedUpdate()
    {
        RemoveDeadOne();
    }

    protected virtual void Spawning()
    {
        Invoke(nameof(Spawning), spawnSpeed);
        if (spawnedEnemies.Count > maxSpawn) return;
        EnemyCtrl prefabs = enemyManagerCtrl.EnemyPrefabs.GetRandomByType<EnemyNormalCtrl>();
        EnemyCtrl newEnemy = enemyManagerCtrl.EnemySpawner.Spawn(prefabs,transform.position);
        newEnemy.gameObject.SetActive(true);
        
        spawnedEnemies.Add(newEnemy);
    }

    protected virtual EnemyCtrl GetEnemies()
    {
        return enemyManagerCtrl.EnemyPrefabs.GetRandomByType<EnemyNormalCtrl>();
    }
    protected virtual void RemoveDeadOne()
    {
        foreach (EnemyCtrl enemyCtrl in spawnedEnemies)
        {
            if (enemyCtrl.DamageRecevier.IsDead())
            {
                spawnedEnemies.Remove(enemyCtrl);
                return;
            }
        }
    }
}
