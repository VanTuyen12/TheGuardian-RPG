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
        this.AddItemTest(20);
        this.AddGoldTest(100);
        Invoke(nameof(AddTest),5f);
    }

    protected virtual void AddTest()
    {
        AddItemTest(8);
    }
    private void AddGoldTest(int count)
    {
        InventoryCtrl inventoryCtrl = GetByName(InvCodeName.Monies);

        ItemInventory gold1 = new ItemInventory();
        gold1.itemProfile = GetProfileByCode(ItemCode.Gold);
        gold1.itemName = gold1.itemProfile.itemName; 
        gold1.itemCount = count ;
        inventoryCtrl.AddItem(gold1);
    }
    private void AddItemTest(int count)
    {
        InventoryCtrl inventoryCtrl1 = GetByName(InvCodeName.Items);
        for (int i = 0; i < count; i++)
        {
            ItemInventory item = new();
            item.itemProfile = GetProfileByCode(ItemCode.Gun);
            item.itemName = item.itemProfile.itemName; 
            item.itemCount = 1 ;
            inventoryCtrl1.AddItem(item);
        }
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
