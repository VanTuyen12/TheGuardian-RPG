using UnityEngine;

public class EnemySpawning : EnemyManagerAbstract
{
    [SerializeField] private float spawnSpeed = 2f;
    //[SerializeField] private int maxSpawn = 10;
    protected override void Start()
    {
        base.Start();
        Invoke(nameof(Spawning), spawnSpeed);
    }

    protected virtual void Spawning()
    {
        Invoke(nameof(Spawning), spawnSpeed);
        EnemyCtrl prefabs = enemyManagerCtrl.EnemyPrefabs.GetRandomPrefab();
        
        EnemyCtrl newEnemy = enemyManagerCtrl.EnemySpawner.Spawn(prefabs,transform.position);
        newEnemy.gameObject.SetActive(true);
    }
}
