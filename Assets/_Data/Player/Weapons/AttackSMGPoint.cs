using UnityEngine;

public class AttackSMGPoint : AttackPoint
{
    
    protected override void SettingAttackPoint()
    {
        transform.localPosition = new Vector3(0,0,0.16f);
    }
}
