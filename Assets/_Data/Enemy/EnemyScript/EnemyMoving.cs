using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class EnemyMoving : MyMonoBehaviour
{
    [SerializeField]protected EnemyCtrl enemyCtrl;
    [SerializeField]protected string pathName = "Path_2" ;
    [SerializeField]protected Path emenyPath;
    [SerializeField]protected Point currentPoint;
    [SerializeField]protected float stopDistance = 1f;
    [SerializeField]protected float pointDistance = Mathf.Infinity;
    [SerializeField]protected bool isFinish = false;
    [SerializeField]protected bool isMoving = false;
    [SerializeField]protected bool canMove  = false;

    protected virtual void OnEnable()
    {
        this.OnReborn();
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadEnemyCtrl();
        
    }

    protected override void Start()
    {
        base.Start();
        this.LoadEnemyPath();
    }


    void FixedUpdate()
    {
        Moving();
        CheckMoving();
    }
    
    protected virtual void Moving()
    {
        if (!this.canMove)
        {
            enemyCtrl.Agent.isStopped = true;
            return;
        }
        
        if (enemyCtrl.DamageRecevier.IsDead())
        {
            enemyCtrl.Agent.isStopped = true;
            return;
        }
          
        FindNextPoint();
        if (currentPoint == null || isFinish == true)
        {
            enemyCtrl.Agent.isStopped = true;
            return;
        }
        enemyCtrl.Agent.isStopped = false;
        this.enemyCtrl.Agent.SetDestination(currentPoint.transform.position);
        
    }

    protected virtual void CheckMoving()
    {
        if(enemyCtrl.Agent.velocity.magnitude > 0.1f) this.isMoving = true;//check on the go
        else  this.isMoving = false;
        
        this.enemyCtrl.Animator.SetBool("isMoving", this.isMoving);
        
    }
    protected virtual void FindNextPoint()
    {
        if (this.currentPoint == null) currentPoint = emenyPath.GetPoint(0);
        this.pointDistance = Vector3.Distance(transform.position, currentPoint.transform.position);

        if (pointDistance < stopDistance)
        {
            currentPoint = currentPoint.NextPoint;
            if (currentPoint == null) isFinish = true;
           
        }
    }
    protected virtual void OnReborn()
    {
       isFinish = false;
       currentPoint = null;
    }
    
    protected virtual void LoadEnemyCtrl()
    {
        if(enemyCtrl != null) return;
        this.enemyCtrl = transform.parent.GetComponent<EnemyCtrl>();
        
        Debug.Log(transform.name+ " :LoadEnemyCtrl",gameObject);
    }
    protected virtual void LoadEnemyPath()
    {
        if(emenyPath != null) return;
        this.emenyPath = PathsManager.Instance.GetPath(pathName);
       // Debug.Log(transform.name+ " :LoadEnemyCtrl",gameObject);
    }
    
}
