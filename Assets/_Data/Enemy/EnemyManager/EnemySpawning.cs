using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class EnemySpawning : EnemyManagerAbstract
{
    [SerializeField] protected float spawnSpeed = 2f;
    public float SpawnSpeed { get => spawnSpeed; set => spawnSpeed = value; }
    [SerializeField] protected int currentSpawn = 20;
    private int maxSpawn = 50;
    private float maxSpawnSpeed = 0.5f;
    public int MaxSpawn { get => currentSpawn; set => currentSpawn = value; }
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
        RoundEnemis();
    }

    protected virtual void RoundEnemis()
    {
        if(currentSpawn >= maxSpawn || spawnSpeed <= maxSpawnSpeed) return;
            currentSpawn += 5;
            spawnSpeed -= 0.1f;
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
            if (spawnedEnemies.Count > currentSpawn) yield break;
            if (canSpawnBoss)
            {
                SpawnEnemis(GetRdEnemiesBoss());
                canSpawnBoss = false;
                continue;
            }

            SpawnEnemis(GetRdEnemiesNormal());
        }
    }

    public virtual void SpawnEnemis(EnemyCtrl prefabs)
    {
        EnemyCtrl newEnemy = enemyManagerCtrl.EnemySpawner.Spawn(prefabs,transform.position);
        
        var path = SetEnemyPathMoving();
        newEnemy.EnemyMoving.SetEnemyPath(path);
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

    protected virtual PathMoving SetEnemyPathMoving()
    {
        return PathsManager.Instance.RandomPath();
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
