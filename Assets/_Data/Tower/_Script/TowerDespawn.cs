using UnityEngine;

public class TowerDespawn : Despawn<TowerCtrl>
{
    protected override void ResetValue()
    {
        base.ResetValue();
        isDespawnByTime = false;
    }
}
