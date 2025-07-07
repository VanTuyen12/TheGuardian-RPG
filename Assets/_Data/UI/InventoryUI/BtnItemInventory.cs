using UnityEngine;

public class BtnItemInventory : ButtonAbstract
{
    protected ItemInventory itemInventory;
    public ItemInventory ItemInventory => itemInventory;
    public virtual void SetItem(ItemInventory itemInv)
    {
        this.itemInventory = itemInv;
    }
    public override void OnClick()
    {
        Debug.Log("OnClick Item");
    }
    
}
