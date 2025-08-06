using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Serialization;

public abstract class TowerCtrl : PoolObj
{
   [SerializeField]protected Transform model;
   public Transform Model => model;
   
   [SerializeField]protected Transform rotation;
   public Transform Rotation => rotation;
   
   [SerializeField]protected TowerTargeting towerTargeting;
   public TowerTargeting TowerTargeting => towerTargeting;
   
   [SerializeField]protected TowerShooting towerShooting;
   public TowerShooting TowerShooting => towerShooting;
   
   [SerializeField]protected LevelAbstract level;
   public LevelAbstract Level => level;
   
   [SerializeField]protected TowerDamageSystem damageSystem;
   public TowerDamageSystem DamageSystem => damageSystem;
   
   [SerializeField]protected List<FirePoint> firePoint;
   public List<FirePoint> FirePoint => firePoint;
   
   

   protected override void LoadComponents()
   {
      base.LoadComponents();
      this.LoadModel();
      this.LoadTowerTargeting();
      this.LoadFirePoint();
      this.LoadTowerShooting();
      this.LoadLevel();
      LoadDamageSystem();
   }
   protected virtual void LoadLevel()
   {
      if(this.level != null) return;
      level =GetComponentInChildren<LevelAbstract>();
      Debug.Log(transform.name + " :LoadLevel",gameObject);
   }
   protected virtual void LoadTowerShooting()
   {
      if(this.towerShooting != null) return;
      towerShooting =GetComponentInChildren<TowerShooting>();
      Debug.Log(transform.name + " :LoadTowerShooting",gameObject);
   }
   
   protected virtual void LoadFirePoint()
   {
      if(this.firePoint.Count > 0) return;
      FirePoint[] point = GetComponentsInChildren<FirePoint>();
      firePoint = point.ToList();
      
      Debug.Log(transform.name + " :LoadTowerTargeting",gameObject);
   }
   protected virtual void LoadTowerTargeting()
   {
      if(this.towerTargeting != null) return;
      towerTargeting = GetComponentInChildren<TowerTargeting>();
      towerTargeting.transform.localPosition = new Vector3(0,1,0);
      Debug.Log(transform.name + " :LoadTowerTargeting",gameObject);
   }
   protected virtual void LoadModel()
   {
      if(this.model != null) return;
      model = this.transform.Find("Model");
      rotation = model.transform.Find("Rotation");
      Debug.Log(transform.name + " :LoadModel",gameObject);
   }

   protected virtual void LoadDamageSystem()
   {
      if(this.damageSystem != null) return;
      damageSystem = GetComponentInChildren<TowerDamageSystem>();
      Debug.Log(transform.name + " :LoadDamageSystem",gameObject);
   }

}
