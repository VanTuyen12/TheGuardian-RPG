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
    [SerializeField] protected LayerMask layerMask; 
    [SerializeField] protected List<EnemyCtrl> enemies = new List<EnemyCtrl>();
    

    protected virtual void FixedUpdate()
    {
        this.FindNearest();
        this.RemoveDeadEnemy();
    }

    protected virtual void FindNearest()
    {
        float nearestDistance = Mathf.Infinity;
        float enemyDistance;

        foreach (EnemyCtrl enemyCtrl in enemies)
        {
            if (!this.CanSeeTarget(enemyCtrl)) continue;
            
                enemyDistance = Vector3.Distance(transform.position,enemyCtrl.transform.position); 
                if (enemyDistance < nearestDistance)
                {
                    nearestDistance = enemyDistance;
                    this.nearest = enemyCtrl;
                }
        }
    }

    protected virtual bool CanSeeTarget(EnemyCtrl target)
    {
        Vector3 directionToTager = target.transform.position - this.transform.position;
        float distanceToTager = directionToTager.magnitude;
        Ray rayToTager = new Ray(this.transform.position, directionToTager);
        
        if (Physics.Raycast( rayToTager, out RaycastHit hitInfo, distanceToTager , layerMask))
        {
            Vector3 directionToCollder = hitInfo.point - this.transform.position;
            float distanceToCollider = directionToCollder.magnitude;
            Debug.DrawRay(this.transform.position, directionToCollder.normalized * distanceToCollider, Color.red);
            return false;
        }
        
        Debug.DrawRay(this.transform.position, directionToTager.normalized * distanceToTager, Color.green);
        return true;
    }
    
    protected virtual void OnTriggerEnter(Collider collider)
    {
        this.AddEnemy(collider);
        //Debug.Log("OnTriggerEnter: " + other.name);
    }

    protected virtual void OnTriggerExit(Collider collider)
    {
        this.RemoveEnemy(collider);
        //Debug.Log("OnTriggerExit: " + other.name);
    }

    protected virtual void AddEnemy(Collider collider)
    {
        if (collider.name != Const.TOWER_TARGETABLES) return;
        EnemyCtrl enemyCtrl = collider.transform.parent.GetComponent<EnemyCtrl>();
        if(enemyCtrl.DamageRecevier.IsDead()) return;
        
        this.enemies.Add(enemyCtrl);
    }

    protected virtual void RemoveEnemy(Collider collider)
    {
        foreach (EnemyCtrl enemyCtrl in enemies)
        {
            if (collider.transform.parent.name == enemyCtrl.name)
            {
                if (enemyCtrl == nearest) nearest = null;
                
                enemies.Remove(enemyCtrl);
                return;
            }
        }
    }
    
    protected virtual void RemoveDeadEnemy()
    {
        foreach (EnemyCtrl enemyCtrl in enemies)
        {
            if (enemyCtrl.DamageRecevier.IsDead())
            {
                if (enemyCtrl == this.nearest) this.nearest = null;
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