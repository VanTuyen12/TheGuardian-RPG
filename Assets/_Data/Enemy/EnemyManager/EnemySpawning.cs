using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawning : EnemyManagerAbstract
{
    [SerializeField] protected float spawnSpeed = 2f;
    public float SpawnSpeed { get => spawnSpeed; set => spawnSpeed = value; }
    [SerializeField] protected int maxSpawn = 20;
    public int MaxSpawn { get => maxSpawn; set => maxSpawn = value; }
    [SerializeField]protected List<EnemyCtrl> spawnedEnemies = new();
    [SerializeField] protected bool canSpawnBoss;
    protected Coroutine Spawning;

    private void OnEnable()
    {
        GameEvent.OnSpawning += GameEventOnOnSpawning; 
    }

    private void OnDisable()
    {
        GameEvent.OnSpawning -= GameEventOnOnSpawning;
    }

    private void GameEventOnOnSpawning(bool obj)
    {
        canSpawnBoss = obj;
    }

    protected override void Start()
    {
        base.Start();
        Spawning = StartCoroutine(EnemiesSpawnLoop());
    }

    protected virtual void FixedUpdate()
    {
        RemoveDeadOne();
    }
    protected virtual IEnumerator EnemiesSpawnLoop()
    {
        while (true)
        {
            yield return new WaitForSeconds(this.spawnSpeed);
            if (spawnedEnemies.Count > maxSpawn) yield break;
            if (canSpawnBoss)
            {
                SpawmBoss();
                canSpawnBoss = false;
                continue;;
            }
            
            EnemyCtrl prefabs = GetRdEnemiesNormal();
            EnemyCtrl newEnemy = enemyManagerCtrl.EnemySpawner.Spawn(prefabs,transform.position);
            newEnemy.gameObject.SetActive(true);
            spawnedEnemies.Add(newEnemy);
        }
    }

    public virtual void SpawmBoss()
    {
        if (spawnedEnemies.Count > maxSpawn) return;
        EnemyCtrl prefabs = GetRdEnemiesBoss();
        EnemyCtrl newEnemy = enemyManagerCtrl.EnemySpawner.Spawn(prefabs,transform.position);
        newEnemy.gameObject.SetActive(true);
        spawnedEnemies.Add(newEnemy);
    }
    protected virtual EnemyCtrl GetRdEnemiesNormal()
    {
        return enemyManagerCtrl.EnemyPrefabs.GetRandomByType<EnemyNormalCtrl>();
    }
    protected virtual EnemyCtrl GetRdEnemiesBoss()
    {
        return enemyManagerCtrl.EnemyPrefabs.GetRandomByType<EnemyBossCtrl>();
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
