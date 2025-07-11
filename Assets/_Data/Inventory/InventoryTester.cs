using com.cyborgAssets.inspectorButtonPro;
using UnityEngine;

public class InventoryTester : MyMonoBehaviour
{
    [ProButton]
    private void AddGoldTest(int count)
    {
        InventoryCtrl inventoryCtrl = InventoryManager.Instance.GetByCodeName(InvCodeName.Currency);

        ItemInventory gold1 = new ItemInventory();
        gold1.itemProfile = InventoryManager.Instance.GetProfileByCode(ItemCode.Gold);
        gold1.itemName = gold1.itemProfile.itemName; 
        gold1.itemCount = count ;
        inventoryCtrl.AddItem(gold1);
    }
    
    [ProButton]
    private void RemoveGoldTest(int count)
    {
        InventoryCtrl inventoryCtrl1 = InventoryManager.Instance.GetByCodeName(InvCodeName.Currency);
            ItemInventory item = new();
            item.itemProfile = InventoryManager.Instance.GetProfileByCode(ItemCode.Gold);
            item.itemName = item.itemProfile.itemName; 
            item.itemCount = count ;
            inventoryCtrl1.RemoveItem(item);
    }
    
    [ProButton]
    private void AddItemTest(ItemCode itemCode,int count)
    {
        InventoryCtrl inventoryCtrl1 = InventoryManager.Instance.GetByCodeName(InvCodeName.Items);
        for (int i = 0; i < count; i++)
        {
            ItemInventory item = new();
            item.itemProfile = InventoryManager.Instance.GetProfileByCode(itemCode);
            item.itemName = item.itemProfile.itemName; 
            item.itemCount = 1 ;
            inventoryCtrl1.AddItem(item);
        }
    }
    
    [ProButton]
    private void RemoveItemTest(ItemCode itemCode,int count)
    {
        InventoryCtrl inventoryCtrl1 = InventoryManager.Instance.GetByCodeName(InvCodeName.Items);
        for (int i = 0; i < count; i++)
        {
            ItemInventory item = new();
            item.itemProfile = InventoryManager.Instance.GetProfileByCode(itemCode);
            item.itemName = item.itemProfile.itemName; 
            item.itemCount = 1 ;
            inventoryCtrl1.RemoveItem(item);
        }
    }
}
