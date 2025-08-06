using System;

using UnityEngine;
using UnityEngine.Serialization;

public class TextBullet1Count : TextAbstract
{
    protected virtual void FixedUpdate()
    {
        this.LoadGoldCount();
    }

    public virtual void LoadGoldCount()
    {
        ItemInventory item = InventoryManager.Instance.Items().FindItem(ItemCode.Bullet1);
        string goldCount;
        if (item == null)  goldCount = "0";
        else goldCount = item.itemCount.ToString();
        
        txtProUi.text = goldCount;
    }
    
}
