using System;

using UnityEngine;
using UnityEngine.Serialization;

public class TextGoldCount : TextAbstract
{
    protected virtual void FixedUpdate()
    {
        this.LoadGoldCount();
    }

    public virtual void LoadGoldCount()
    {
        ItemInventory item = InventoryManager.Instance.Currency().FindItem(ItemCode.Gold);
        string goldCount;
        if (item == null)  goldCount = "0";
        else goldCount = item.itemCount.ToString();
        
        txtProUi.text = goldCount;
    }
    
}
