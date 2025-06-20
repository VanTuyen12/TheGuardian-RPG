using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class WallDamageReceiver : DamageRecevier
{
    [SerializeField] protected BoxCollider boxCollider;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadBoxCollider();
    }

    protected virtual void LoadBoxCollider()
    {
        if(boxCollider != null) return;
        boxCollider = GetComponent<BoxCollider>();
        boxCollider.isTrigger = false;
        Debug.Log(transform.name + " has loaded WallDamageReceiver component");
    }

    protected override void ResetValue()
    {
        base.ResetValue();
        this.isImmortal = true;
    }
}
