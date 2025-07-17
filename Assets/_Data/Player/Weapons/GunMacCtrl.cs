using UnityEngine;

public class GunMacCtrl : WeaponAbstract
{
    protected override void ResetValue()
    {
        base.ResetValue();
        transform.localPosition = new Vector3(-0.027f, 0.1325f, 0.0197f);
        transform.localRotation = Quaternion.Euler(14.31f, 276.1f, 92f);
    }
}
