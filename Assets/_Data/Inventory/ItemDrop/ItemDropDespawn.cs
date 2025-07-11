using UnityEngine;

public class ItemDropDespawn : Despawn<ItemDropCtrl>
{
   public override void DoDespawn()
   {
      ItemDropCtrl itemDropCtrl = parent as ItemDropCtrl;
      
      ItemInventory item = new();
      item.itemProfile = InventoryManager.Instance.GetProfileByCode(itemDropCtrl.ItemCode);
      item.itemCount = itemDropCtrl.ItemCount;
      item.itemName = itemDropCtrl.GetName();
      
      InvCodeName invCodeName = item.ItemProfile.invCodeName;
      InventoryCtrl inventoryCtrl = InventoryManager.Instance.GetByCodeName(invCodeName);
      
      inventoryCtrl.AddItem(item);
      
      base.DoDespawn();
   }
}
