using System;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class EmenyMoving : MyMonoBehaviour
{
    [SerializeField]protected GameObject target;
    [SerializeField]protected EnemyCtrl enemyCtrl;
    [SerializeField]protected string pathName = "Path_1" ;
    [SerializeField]protected Path emenyPath;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadEnemyCtrl();
        this.LoadTarget();
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
        this.enemyCtrl.Agent.SetDestination(target.transform.position);
    }
    protected virtual void LoadTarget()
    {
        if(target != null) return;
        target = GameObject.Find("TargetMoving");
        
        Debug.Log(transform.name + " :LoadTarget",gameObject);
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
