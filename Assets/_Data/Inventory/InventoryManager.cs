using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : Singleton<InventoryManager>
{
    [SerializeField]protected List<InventoryCtrl> inventories = new();
    [SerializeField]protected List<ItemProfileSO> itemProfiles = new();
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadInventories();
        this.LoaditemProfiles();
    }

    protected virtual void LoaditemProfiles()
    {
        if (itemProfiles.Count > 0) return;
        ItemProfileSO[] item = Resources.LoadAll<ItemProfileSO>("ItemProfiles");
        itemProfiles.AddRange(item);
        
        Debug.Log(transform.name +" LoaditemProfiles: ",gameObject);
    }
    public virtual void AddItem(ItemInventory itemInventory)
    {
        InventoryCodeName invCodeName = itemInventory.ItemProfile.invCodeName;
        InventoryCtrl inventoryCtrl = GetByCodeName(invCodeName);
        inventoryCtrl.AddItem(itemInventory);
    }

    public virtual void AddItem(ItemCode itemCode, int itemCount)
    {
        ItemProfileSO itemProfile = GetProfileByCode(itemCode);
        ItemInventory item = new(itemProfile, itemCount);
        this.AddItem(item);
    }
    public virtual void RemoveItem(ItemCode itemCode, int itemCount)
    {
        ItemProfileSO itemProfile = GetProfileByCode(itemCode);
        ItemInventory item = new(itemProfile, itemCount);
        this.RemoveItem(item);
    }

    public virtual void RemoveItem(ItemInventory itemInventory)
    {
        InventoryCodeName invCodeName = itemInventory.ItemProfile.invCodeName;
        InventoryCtrl inventoryCtrl = GetByCodeName(invCodeName);
        inventoryCtrl.RemoveItem(itemInventory);
    }
    protected virtual void LoadInventories()
    {
        if (inventories.Count > 0) return;
        foreach (Transform child in transform)
        {
            InventoryCtrl inventoryCtrl = child.GetComponent<InventoryCtrl>();
            if (inventoryCtrl == null) continue;
            inventories.Add(inventoryCtrl);
        }
        Debug.Log(transform.name +"LoadInventories: ",gameObject);
    }

    public virtual InventoryCtrl GetByCodeName(InventoryCodeName inventoryName)
    {
        foreach (InventoryCtrl inventory in inventories)
        {
            if(inventory.GetName() == inventoryName) return inventory;
        }
        return null;
    }
    public virtual ItemProfileSO GetProfileByCode(ItemCode itemCodeName)
    {
        foreach (ItemProfileSO itemProfile in itemProfiles)
        {
            if(itemProfile.itemCode == itemCodeName) return itemProfile;
        }
        return null;
    }

    public virtual InventoryCtrl Currency()
    {
        return GetByCodeName(InventoryCodeName.Currency);
    }
    
    public virtual InventoryCtrl Items()
    {
        return GetByCodeName(InventoryCodeName.Items);
    }
}
