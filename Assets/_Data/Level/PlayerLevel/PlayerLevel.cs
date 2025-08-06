using UnityEngine;

public class PlayerLevel : LevelByItem
{
    private float UpgradeFast = 3f;
    private float UpgradeSlow = 7f;
   
   protected override void LevelingUp()
   {
      base.LevelingUp();
      PlayerCtrl player = PlayerCtrl.Instance;
      if (player == null) return;
      
       player.DamageSystem.UpgradeDamageFast(UpgradeFast);
       player.DamageSystem.UpgradeDamageSlow(UpgradeSlow);
      
     
   }
   
}
