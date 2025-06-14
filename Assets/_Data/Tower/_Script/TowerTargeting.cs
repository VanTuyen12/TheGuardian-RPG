using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(SphereCollider))]
public class TowerTargeting : MyMonoBehaviour
{
    [SerializeField] protected Rigidbody rb;
    [SerializeField] protected SphereCollider sphereCollider;
    [SerializeField] protected EnemyCtrl nearest;
    public EnemyCtrl Nearest => nearest;
    [SerializeField] protected List<EnemyCtrl> enemies = new List<EnemyCtrl>();

    protected virtual void FixedUpdate()
    {
        this.FindNearest();
    }

    protected virtual void FindNearest()
    {
        float nearestDistance = Mathf.Infinity;
        float enemyDistance;

        foreach (EnemyCtrl enemyCtrl in enemies)
        {
            enemyDistance = Vector3.Distance(transform.position,enemyCtrl.transform.position); 
            if (enemyDistance < nearestDistance)
            {
                nearestDistance = enemyDistance;
                this.nearest = enemyCtrl;
            }
        }
    }
    protected virtual void OnTriggerEnter(Collider other)
    {
        this.AddEnemy(other);
        //Debug.Log("OnTriggerEnter: " + other.name);
    }

    protected virtual void OnTriggerExit(Collider other)
    {
        this.RemoveEnemy(other);
        //Debug.Log("OnTriggerExit: " + other.name);
    }

    protected virtual void AddEnemy(Collider collider)
    {
        if (collider.name != Const.TOWER_TARGETABLES) return;
        EnemyCtrl enemyCtrl = collider.transform.parent.GetComponent<EnemyCtrl>();
        
        this.enemies.Add(enemyCtrl);
    }

    protected virtual void RemoveEnemy(Collider collider)
    {
        foreach (EnemyCtrl enemyCtrl in enemies)
        {
            if (collider.transform.parent.name == enemyCtrl.name)
            {
                enemies.Remove(enemyCtrl);
                return;
            }
        }
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadRigidbody();
        this.SphereCollider();
    }

    protected virtual void LoadRigidbody()
    {
        if (this.rb != null) return;
        this.rb = this.GetComponent<Rigidbody>();
        rb.useGravity = false;
        Debug.Log(transform.name + " :LoadRigidbody", gameObject);
    }

    protected virtual void SphereCollider()
    {
        if (this.sphereCollider != null) return;
        this.sphereCollider = this.GetComponent<SphereCollider>();
        sphereCollider.isTrigger = true;
        sphereCollider.radius = 6f;
        Debug.Log(transform.name + " :LoadRigidbody", gameObject);
    }

    
}