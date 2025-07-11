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

    private void LoaditemProfiles()
    {
        if (itemProfiles.Count > 0) return;
        ItemProfileSO[] item = Resources.LoadAll<ItemProfileSO>("ItemProfiles");
        itemProfiles.AddRange(item);
        
        Debug.Log(transform.name +" LoaditemProfiles: ",gameObject);
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

    public virtual InventoryCtrl GetByCodeName(InvCodeName inventoryName)
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
        return GetByCodeName(InvCodeName.Currency);
    }
    
    public virtual InventoryCtrl Items()
    {
        return GetByCodeName(InvCodeName.Items);
    }
}
