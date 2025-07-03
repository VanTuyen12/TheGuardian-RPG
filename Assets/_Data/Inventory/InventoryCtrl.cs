using System.Collections.Generic;
using UnityEngine;

public abstract class InventoryCtrl : MyMonoBehaviour
{
    [SerializeField]protected List<ItemInventory> items = new();
    public abstract InvCodeName GetName();

    public virtual void AddItem(ItemInventory item)
    {
        
        ItemInventory itemExsit = FindItem(item.itemProfile.itemCode);
        if ( !item.itemProfile.isStackable ||itemExsit == null)
        {
            items.Add(item);
            return;
        }

        if (item.itemCount < 0 ) return;
        itemExsit.itemCount += item.itemCount;
    }

    public virtual ItemInventory FindItem(ItemCode itemCode)
    {
        foreach (ItemInventory itemInventory in items)
        {
            if (itemInventory.itemProfile.itemCode == itemCode) return itemInventory;
        }
        return null;
    }
}
