using UnityEngine;

public class MusicDespawn : Despawn<SoundCtrl>
{
    protected override void ResetValue()
    {
        base.ResetValue();
        isDespawnByTime = false;
    }
}
