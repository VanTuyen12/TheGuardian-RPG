using UnityEngine;

public class SpawnEnemy : MyMonoBehaviour
{
    [SerializeField] protected EnemySpawner enemySpawn;
    [SerializeField] protected EnemyCtrl enemyCtrl;
    [SerializeField] protected float timeLine = 2f;
    protected override void Awake()
    {
        base.Awake();
        Invoke(nameof(Spawn_Enemy),timeLine);
        
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadEnemySpawn();
        this.LoadEnemyCtrl();
    }
    
    protected virtual void LoadEnemySpawn()
    {
        if(enemySpawn!=null ) return;
        enemySpawn = transform.parent.GetComponent<EnemySpawner>();
    }
    
    protected virtual void LoadEnemyCtrl()
    {
        if(enemyCtrl!=null ) return;
        enemyCtrl = FindAnyObjectByType<EnemyCtrl>();
    }

    protected virtual void Spawn_Enemy()
    {
        Invoke(nameof(Spawn_Enemy),timeLine);
        enemySpawn.Spawn(enemyCtrl);
    }
}
