using UnityEngine;

public class ProjectHit3DamageSender : EffectDamageSender
{
    protected override string GetHitName()
    {
        return nameof(HitCodeName.Hit3);
    }
}
