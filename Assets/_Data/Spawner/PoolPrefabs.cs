using System.Collections.Generic;
using UnityEngine;

public abstract class PoolPrefabs<T> : MyMonoBehaviour where T : MonoBehaviour 
{
   [SerializeField]protected List<T> poolPrefabs = new List<T>();
   

   protected override void LoadComponents()
   {
      base.LoadComponents();
      this.LoadPrefabs();
      this.HidePrefabs();
   }

   protected virtual void LoadPrefabs()
   {
      if(this.poolPrefabs.Count > 0) return;
      foreach (Transform child in transform)
      {
        T prefabs =  child.GetComponent<T>();
        if (prefabs != null) poolPrefabs.Add(prefabs);
      }
      //Debug.Log(transform.name + " :LoadPrefabs ",gameObject);
   }

   protected virtual void HidePrefabs()
   {
      foreach (T prefab in poolPrefabs)
      {
         prefab.gameObject.SetActive(false);
      }
   }

   public virtual T GetRandom()
   {
      int rand = Random.Range(0, poolPrefabs.Count);
      return poolPrefabs[rand];
   }
   
   public virtual T GetByName(string prefabName)
   {
      foreach (T prefab in poolPrefabs)
      {
         if (prefab.name == prefabName )
         {
            return prefab;
         }
      }
      return null;
   }
}
