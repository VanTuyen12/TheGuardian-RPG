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

   protected override void LoadComponents()
   {
      base.LoadComponents();
      this.LoadModel();
      this.LoadTowerTargeting();
      this.LoadBulletSpawner();
      this.LoadBullet();
   }
   protected virtual void LoadBulletSpawner()
   {
      if(this.bulletSpawner != null) return;
      bulletSpawner = FindAnyObjectByType<BulletSpawner>();
      Debug.Log(transform.name + " :LoadBulletSpawner",gameObject);
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
      model = this.transform.Find("ModelHolder/Model");
      rotation = model.transform.Find("Rotation");
      Debug.Log(transform.name + " :LoadModel",gameObject);
   }

}
