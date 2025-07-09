using UnityEngine;

public class ItemDropDespawn : Despawn<ItemDropCtrl>
{
   public override void DoDespawn()
   {
      this.AddGoldWhenDead();
      base.DoDespawn();
   }
   
   protected virtual void AddGoldWhenDead()
   {
      var itemDropCtrl = parent as ItemDropCtrl;
      
         ItemInventory item = new();
        item.itemProfile = InventoryManager.Instance.GetProfileByCode(itemDropCtrl.ItemCode);
        item.itemCount = itemDropCtrl.ItemCount;
        InventoryManager.Instance.GetByCodeName(itemDropCtrl.InvCodeName).AddItem(item);
   }
}
