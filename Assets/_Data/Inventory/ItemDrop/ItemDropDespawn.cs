using UnityEngine;

public class ItemDropDespawn : Despawn<ItemDropCtrl>
{
   public override void DoDespawn()
   {
      ItemDropCtrl itemDropCtrl = parent as ItemDropCtrl;
      
   
      InventoryManager.Instance.AddItem(itemDropCtrl.ItemCode, itemDropCtrl.ItemCount);
      
      base.DoDespawn();
   }
}
