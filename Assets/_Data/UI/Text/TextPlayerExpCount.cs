using UnityEngine;

public class TextPlayerExpCount : TextAbstract
{
    protected virtual void FixedUpdate()
    {
        this.LoadGoldCount();
    }

    public virtual void LoadGoldCount()
    {
        ItemInventory item = InventoryManager.Instance.Currency().FindItem(ItemCode.PlayerExp);
        string goldCount;
        if (item == null)  goldCount = "0";
        else goldCount = item.itemCount.ToString();
        
        txtCount.text = goldCount;
    }
}
