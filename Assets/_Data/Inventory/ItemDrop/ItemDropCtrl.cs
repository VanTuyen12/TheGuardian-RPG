using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public abstract class ItemDropCtrl : PoolObj
{
    [SerializeField] protected Rigidbody rigi;
    public Rigidbody Rigidbody => rigi;
    protected InventoryCodeName iveCodeName;
    public InventoryCodeName InventoryCodeName => iveCodeName;
    protected ItemCode itemCode;
    public ItemCode ItemCode => itemCode;
    protected int itemCount;
    public int ItemCount => itemCount;

    public virtual void SetValue(InventoryCodeName inventoryCodeName,ItemCode itemCode, int itemCount)
    {
        this.iveCodeName = inventoryCodeName;
        this.itemCode = itemCode;
        this.itemCount = itemCount;
    }
    
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
