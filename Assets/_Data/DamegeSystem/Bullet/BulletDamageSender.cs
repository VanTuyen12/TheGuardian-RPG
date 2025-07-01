using System;
using UnityEngine;
using UnityEngine.Serialization;

[RequireComponent(typeof(SphereCollider))]
public class BulletDamageSender : DamageSender
{
    [SerializeField]protected SphereCollider sphereCollider;
    [SerializeField]protected Bullet bullet;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadCollider();
        this.LoadBullet();
    }
    protected virtual void LoadBullet()
    {
        if (bullet != null) return;
        bullet = GetComponentInParent<Bullet>();
        Debug.Log(transform.name+ " :LoadBullet ",gameObject);
    }
    
    protected virtual void LoadCollider()
    {
        if (sphereCollider != null) return;
        sphereCollider = GetComponent<SphereCollider>();
        sphereCollider.isTrigger = true;
        sphereCollider.radius = 0.025f;
        Debug.Log(transform.name + " :LoadCollider ",gameObject);
    }

    protected virtual void OnTriggerEnter(Collider collider)
    {
       DamageRecevier damageRecevier = collider.GetComponent<DamageRecevier>();
       if (damageRecevier == null) return;
       this.SendDamege(damageRecevier);
       bullet.Despawn.DoDespawn();
      // Debug.Log(" :OnTriggerEnter "+ collider.name);
    }
}
