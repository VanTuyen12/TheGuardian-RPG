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
    }

    protected override void Start()
    {
        base.Start();
        this.AddItemTest();
    }

    private void AddItemTest()
    {
        InventoryCtrl inventoryCtrl = GetByName(InvCodeName.Monies);

        ItemInventory gold1 = new ItemInventory();
        gold1.itemProfile = GetProfileByCode(ItemCode.Gold);
        gold1.itemName = gold1.itemProfile.itemName; 
        gold1.itemCount = 11 ;
        inventoryCtrl.AddItem(gold1);
        
        ItemInventory gold2 = new ItemInventory();
        gold2.itemProfile = GetProfileByCode(ItemCode.Gold);
        gold2.itemName = gold2.itemProfile.itemName; 
        gold2.itemCount = -999 ;
        inventoryCtrl.AddItem(gold2);
        
        InventoryCtrl inventoryCtrl1 = GetByName(InvCodeName.Items);

        for (int i = 0; i < 20; i++)
        {
            ItemInventory item = new();
            item.itemProfile = GetProfileByCode(ItemCode.Gun);
            item.itemName = item.itemProfile.itemName; 
            item.itemCount = 1 ;
            inventoryCtrl1.AddItem(item);
        }
        
        
        /*ItemInventory item2 = new ItemInventory();
        item2.itemProfile = GetProfileByCode(ItemCode.Gun);
        item2.itemName = item2.itemProfile.itemName; 
        item2.itemCount = 999 ;
        inventoryCtrl1.AddItem(item2);*/
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

    public virtual InventoryCtrl GetByName(InvCodeName inventoryName)
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

    public virtual InventoryCtrl Monies()
    {
        return GetByName(InvCodeName.Monies);
    }
    
    public virtual InventoryCtrl Items()
    {
        return GetByName(InvCodeName.Items);
    }
}
