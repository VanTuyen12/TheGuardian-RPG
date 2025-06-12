using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class EmenyMoving : MyMonoBehaviour
{
    [SerializeField]protected EnemyCtrl enemyCtrl;
    [SerializeField]protected string pathName = "Path_1" ;
    [SerializeField]protected Path emenyPath;
    [SerializeField]protected Point currentPoint;
    [SerializeField]protected float stopDistance = 1f;
    [SerializeField]protected float pointDistance = Mathf.Infinity;
    [SerializeField]protected bool isFinish = false;
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
        EnemyMoving();
    }
    
    protected virtual void EnemyMoving()
    {
        FindNextPoint();
        if (currentPoint == null || isFinish == true)
        {
            enemyCtrl.Agent.isStopped = true;
            return;
        }
        this.enemyCtrl.Agent.SetDestination(currentPoint.transform.position);
        
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
        
        Debug.Log(transform.name+ " :LoadEnemyCtrl",gameObject);
    }
    
}
