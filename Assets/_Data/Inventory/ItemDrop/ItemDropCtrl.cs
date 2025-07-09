using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public abstract class ItemDropCtrl : PoolObj
{
    [SerializeField] protected Rigidbody rigi;
    public Rigidbody Rigidbody => rigi;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadRigidbody();
    }

    protected virtual void LoadRigidbody()
    {
        if (this.rigi != null) return;
        this.rigi = GetComponent<Rigidbody>();
        Debug.Log(transform.name + ":LoadRigidbody", gameObject);
    }
}
