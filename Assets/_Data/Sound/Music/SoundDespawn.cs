using UnityEngine;

public class SoundDespawn : Despawn<SoundCtrl>
{
   protected override void ResetValue()
   {
      base.ResetValue();
      timeLife = 2f;
      currentTime = 2f;
   }
}
