using UnityEngine;

public class EnemyDespawn : Despawn<EnemyCtrl>
{
    protected override void DespawnChecking()
    {
        if (parent.DamageRecevier.IsDead())
        {
            DoDespawn();
        }
    }
}
