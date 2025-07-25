using System;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class HandleImpact : MyMonoBehaviour
{
   [SerializeField]protected SphereCollider sphereCollider;

   protected override void LoadComponents()
   {
      base.LoadComponents();
      this.LoadSphereCollider();
   }

   protected virtual void LoadSphereCollider()
   {
      if(sphereCollider != null) return;
      sphereCollider = GetComponent<SphereCollider>();
      sphereCollider.isTrigger = true;
      sphereCollider.radius = 0.3f;
      Debug.Log(transform.name + "LoadSphereCollider",gameObject);
   }

   protected virtual void OnTriggerEnter(Collider collider)
   {
      if (CheckOpenTowerUI(collider))
      {
         GameEvent.TriggerTowerCollider(true, collider.gameObject);
      }
      
      ItemPicker(collider);
   }

   private void OnTriggerExit(Collider collider)
   {
      if (CheckOpenTowerUI(collider))
      {
         GameEvent.TriggerTowerCollider(false, collider.gameObject);
      }
   }

   protected virtual bool CheckOpenTowerUI(Collider other)
   {
      return other.transform.GetComponent<GunStandCtrl>();
   }
   protected virtual void ItemPicker(Collider other)
   {
      if(other.transform.parent == null) return;
      ItemDropCtrl itemDropCtrl = other.transform.parent.GetComponent<ItemDropCtrl>();
      if(itemDropCtrl == null) return;
      
      itemDropCtrl.Despawn.DoDespawn();
   }
}
