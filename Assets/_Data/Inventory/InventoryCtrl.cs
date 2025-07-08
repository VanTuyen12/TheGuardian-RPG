using System.Collections.Generic;
using UnityEngine;

public abstract class InventoryCtrl : MyMonoBehaviour
{
    [SerializeField]protected List<ItemInventory> items = new();
    public List<ItemInventory> Items => items;
    public abstract InvCodeName GetName();

    public virtual void AddItem(ItemInventory item)
    {
        
        ItemInventory itemExsit = FindItem(item.itemProfile.itemCode);
        if ( !item.itemProfile.isStackable ||itemExsit == null)
        {
            item.itemId = Random.Range(0, int.MaxValue);
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
    public virtual bool RemoveItem(ItemInventory item)
    {
        ItemInventory itemExsit = FindItemNotEmpty(item.itemProfile.itemCode);
        if (itemExsit == null) return false;
        if (itemExsit.itemCount < item.itemCount) return false;
        itemExsit.itemCount -= item.itemCount;
        if (itemExsit.itemCount <= 0) items.Remove(itemExsit);
        return true;
    }
    
    public virtual ItemInventory FindItemNotEmpty(ItemCode itemCode)
    {
        foreach (ItemInventory itemInventory in items)
        {
            if (itemInventory.itemProfile.itemCode != itemCode) continue;
            if(itemInventory.itemCount > 0) return itemInventory;
        }
        return null;
    }
}
