using UnityEngine;

public abstract class AttackPoint : MyMonoBehaviour
{
    protected override void Reset()
    {
             base.Reset();
             SettingAttackPoint();
    }

    protected abstract void SettingAttackPoint();
}
