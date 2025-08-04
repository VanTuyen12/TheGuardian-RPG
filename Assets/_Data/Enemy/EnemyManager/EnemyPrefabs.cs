using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyPrefabs : PoolPrefabs<EnemyCtrl>
{
    public virtual U GetRandomByType<U>() where U : EnemyCtrl
    {
        var filtered  = poolPrefabs.Where(prefab => prefab is U).ToList();
        
        if (filtered .Count == 0) return null;
        
        int rand = Random.Range(0, filtered.Count);
        return (U)filtered [rand];
    }
}
