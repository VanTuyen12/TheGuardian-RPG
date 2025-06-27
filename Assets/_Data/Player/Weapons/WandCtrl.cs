using UnityEngine;

public class WandCtrl : WeaponAbstract
{
    protected override void ResetValue()
    {
        base.ResetValue();
        transform.localPosition = new Vector3(-0.05f, 0.14f, 0.033f);
        transform.localRotation = Quaternion.Euler(-100f, 100f, -21f);
    }
    
}
