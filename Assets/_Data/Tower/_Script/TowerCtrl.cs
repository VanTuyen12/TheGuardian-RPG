using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TowerCtrl : MyMonoBehaviour
{
   [SerializeField]protected Transform model;
   public Transform Model => model;
   
   [SerializeField]protected Transform rotation;
   public Transform Rotation => rotation;
   
   [SerializeField]protected TowerTargeting towerTargeting;
   public TowerTargeting TowerTargeting => towerTargeting;
   
   [SerializeField]protected BulletSpawner bulletSpawner;
   public BulletSpawner BulletSpawner => bulletSpawner;
   
   [SerializeField]protected Bullet bullet;
   public Bullet Bullet => bullet;
   
   [SerializeField]protected List<FirePoint> firePoint;
   public List<FirePoint> FirePoint => firePoint;

   protected override void Awake()
   {
      base.Awake();
      this.HidePrefabs();
   }

   protected virtual void HidePrefabs()
   {
      bullet.gameObject.SetActive(false);
   }

   protected override void LoadComponents()
   {
      base.LoadComponents();
      this.LoadModel();
      this.LoadTowerTargeting();
      this.LoadBulletSpawner();
      this.LoadBullet();
      this.LoadFirePoint();
   }
   protected virtual void LoadBulletSpawner()
   {
      if(this.bulletSpawner != null) return;
      bulletSpawner = FindAnyObjectByType<BulletSpawner>();
      Debug.Log(transform.name + " :LoadBulletSpawner",gameObject);
   }
   
   protected virtual void LoadFirePoint()
   {
      if(this.firePoint.Count > 0) return;
      FirePoint[] point = GetComponentsInChildren<FirePoint>();
      firePoint = point.ToList();
      
      Debug.Log(transform.name + " :LoadTowerTargeting",gameObject);
   }
   protected virtual void LoadBullet()
   {
      if(this.bullet != null) return;
      bullet = bulletSpawner.GetComponentInChildren<Bullet>();
      Debug.Log(transform.name + " :LoadBullet",gameObject);
   }
   protected virtual void LoadTowerTargeting()
   {
      if(this.towerTargeting != null) return;
      towerTargeting = GetComponentInChildren<TowerTargeting>();
      Debug.Log(transform.name + " :LoadTowerTargeting",gameObject);
   }
   protected virtual void LoadModel()
   {
      if(this.model != null) return;
      model = this.transform.Find("Model");
      rotation = model.transform.Find("Rotation");
      Debug.Log(transform.name + " :LoadModel",gameObject);
   }

}
