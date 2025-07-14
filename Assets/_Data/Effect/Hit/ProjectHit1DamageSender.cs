using UnityEngine;

public class ProjectHit1DamageSender : EffectDamageSender
{
    protected override string GetHitName()
    {
        return nameof(HitCodeName.Hit1);
    }
}
