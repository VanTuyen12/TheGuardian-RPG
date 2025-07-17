using UnityEngine;

public class ProjectHit2DamageSender : EffectDamageSender
{
    protected override string GetHitName()
    {
        return nameof(HitCodeName.Hit2);
    }
}
