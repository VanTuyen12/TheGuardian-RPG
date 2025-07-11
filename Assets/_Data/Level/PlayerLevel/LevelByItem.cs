using UnityEngine;

public abstract class LevelByItem : LevelAbstract
{
   [SerializeField] protected ItemInventory playerExp;

   protected override int GetCurrentExp()
   {
      if(GetPlayerExp() == null) return 0;
      return GetPlayerExp().itemCount;
   }

   protected override bool DeductExp(int exp)
   {
     return this.GetPlayerExp().Deduct(exp);
   }

   protected virtual ItemInventory GetPlayerExp()
   {
      if(playerExp == null || playerExp.ItemId == 0) playerExp = InventoryManager.Instance.Currency().FindItem(ItemCode.PlayerExp);
      return playerExp;

   } 
}
