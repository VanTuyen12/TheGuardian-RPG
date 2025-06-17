using System;
using UnityEngine;

public abstract class Despawn<T> : DespawnBase where T : PoolObj
{
   [SerializeField] protected float timeLife = 7f;
   [SerializeField] protected float currentTime = 7f;
   [SerializeField] protected Spawner<T> spawner;
   [SerializeField] protected T parent;

   protected virtual void FixedUpdate()
   {
      this.DespawnChecking();
   }

   protected override void LoadComponents()
   {
      base.LoadComponents();
      this.LoadParent();
      this.LoadSpawner();
   }
   
   
   protected virtual void DespawnChecking()
   {
      currentTime -= Time.fixedDeltaTime;
      if (currentTime > 0) return;
      
      spawner.Despawn(parent);
      currentTime = timeLife;
   }
   
   protected virtual void LoadParent()
   {
      if(this.parent != null) return;
      parent = transform.parent.GetComponent<T>();
      Debug.Log(transform.name + " :LoadParent",gameObject);
   }
   
   protected virtual void LoadSpawner()
   {
      if(this.spawner != null) return;
      spawner = parent.transform.parent.GetComponent<Spawner<T>>();
      Debug.Log(transform.name + " :LoadSpawner",gameObject);
   }
}
