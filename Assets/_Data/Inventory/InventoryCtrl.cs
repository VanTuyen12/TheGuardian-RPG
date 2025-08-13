using System.Collections.Generic;
using UnityEngine;

public abstract class InventoryCtrl : MyMonoBehaviour
{
    [SerializeField]protected List<ItemInventory> items = new();
    public List<ItemInventory> Items => items;
    public abstract InventoryCodeName GetName();

    
    public virtual void ClearAllItems()
    {
        if (items != null)
        {
            items.Clear();
        }
    }
    public virtual void AddItem(ItemInventory item)
    {
        
        ItemInventory itemExsit = FindItem(item.ItemProfile.itemCode);
        if ( !item.ItemProfile.isStackable ||itemExsit == null)
        {
            items.Add(item);
            return;
        }

        if (item.itemCount < 0 ) return;
        itemExsit.itemCount += item.itemCount;
    }
    public virtual bool RemoveItem(ItemInventory item)
    {
        ItemInventory itemExist = this.FindItemNotEmpty(item.ItemProfile.itemCode);
        if (itemExist == null) return false;
        if (!itemExist.CanDeduct(item.itemCount)) return false;
        itemExist.Deduct(item.itemCount);
        if (itemExist.itemCount == 0) this.items.Remove(itemExist);
        return true;
    }
    
    public virtual ItemInventory FindItem(ItemCode itemCode)
    {
        foreach (ItemInventory itemInventory in items)
        {
            if (itemInventory.ItemProfile.itemCode == itemCode) return itemInventory;
        }
        return null;
    }
    
    public virtual ItemInventory FindItemNotEmpty(ItemCode itemCode)
    {
        foreach (ItemInventory itemInventory in items)
        {
            if (itemInventory.ItemProfile.itemCode != itemCode) continue;
            if(itemInventory.itemCount > 0) return itemInventory;
        }
        return null;
    }
}
