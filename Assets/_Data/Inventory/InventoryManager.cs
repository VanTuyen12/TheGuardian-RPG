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
        gold1.itemCount = 11 ;
        inventoryCtrl.AddItem(gold1);
        
        ItemInventory gold2 = new ItemInventory();
        gold2.itemProfile = GetProfileByCode(ItemCode.Gold);
        gold2.itemCount = -999 ;
        inventoryCtrl.AddItem(gold2);
        
        InventoryCtrl inventoryCtrl1 = GetByName(InvCodeName.Items);

        ItemInventory item1 = new ItemInventory();
        item1.itemProfile = GetProfileByCode(ItemCode.Gun);
        item1.itemCount = 11 ;
        inventoryCtrl1.AddItem(item1);
        
        ItemInventory item2 = new ItemInventory();
        item2.itemProfile = GetProfileByCode(ItemCode.Gun);
        item2.itemCount = 999 ;
        inventoryCtrl1.AddItem(item2);
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

    protected virtual InventoryCtrl GetByName(InvCodeName inventoryName)
    {
        foreach (InventoryCtrl inventory in inventories)
        {
            if(inventory.GetName() == inventoryName) return inventory;
        }
        return null;
    }
    protected virtual ItemProfileSO GetProfileByCode(ItemCode itemCodeName)
    {
        foreach (ItemProfileSO itemProfile in itemProfiles)
        {
            if(itemProfile.itemCode == itemCodeName) return itemProfile;
        }
        return null;
    }
}
