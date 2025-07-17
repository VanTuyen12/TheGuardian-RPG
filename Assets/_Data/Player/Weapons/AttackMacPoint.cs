using UnityEngine;

public class AttackMacPoint : AttackPoint
{
    protected override void SettingAttackPoint()
    {
        transform.localPosition = new Vector3(0.069f,0,0.007f);
    }
}
