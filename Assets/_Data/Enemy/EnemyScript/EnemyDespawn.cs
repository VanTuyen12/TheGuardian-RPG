using UnityEngine;

public class EnemyDespawn : Despawn<EnemyCtrl>
{
    protected override void ResetValue()
    {
        base.ResetValue();
        isDespawnByTime = false;
    }
    
}
