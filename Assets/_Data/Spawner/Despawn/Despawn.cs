using System;
using UnityEngine;

public class Despawn : MyMonoBehaviour
{
   [SerializeField] protected float timeLife = 7f;
   [SerializeField] protected float currentTime = 7f;
   [SerializeField] protected Spawner spawner;

   protected virtual void FixedUpdate()
   {
      this.DespawnChecking();
   }

   public virtual void SetSpawener(Spawner spawner)
   {
      this.spawner = spawner;
   }
   
   protected virtual void DespawnChecking()
   {
      currentTime -= Time.fixedDeltaTime;
      if (currentTime > 0) return;
      
      spawner.Despawn(transform.parent);
      currentTime = timeLife;
   }
}
