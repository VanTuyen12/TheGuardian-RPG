using UnityEngine;
using UnityEngine.AI;

public class EnemyCtrl : MyMonoBehaviour
{
    [SerializeField]protected Transform model;
    [SerializeField]protected NavMeshAgent agent;
    public NavMeshAgent Agent => agent;
    
    [SerializeField]protected Animator animator;
    public Animator Animator => animator;
    
    [SerializeField]protected EnemyTargetable enemyTargetable;
    public EnemyTargetable EnemyTargetable => enemyTargetable;
    
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadNavMeshAgent();
        this.LoadModel();
        this.LoadAnimator();
        this.LoadEnemyTargetable();
    }

    protected virtual void LoadModel()
    {
        if(this.model != null) return;
        model = this.transform.Find("Model");
        Debug.Log(transform.name + " :LoadModel",gameObject);
    }
    protected virtual void LoadEnemyTargetable()
    {
        if(this.enemyTargetable != null) return;
        enemyTargetable = this.transform.GetComponentInChildren<EnemyTargetable>();
        enemyTargetable.transform.localPosition = new Vector3(0f, 1f, 0f);
        Debug.Log(transform.name + " :LoadEnemyTargetable",gameObject);
    }
    
    protected virtual void LoadAnimator()
    {
        if(this.animator != null) return;
        animator = model.GetComponent<Animator>();
        Debug.Log(transform.name + " :LoadAnimator",gameObject);
    }

    protected virtual void LoadNavMeshAgent()
    {
        if(agent != null) return;
        agent = GetComponent<NavMeshAgent>();
        agent.speed = 4f;
        agent.angularSpeed = 200f;
        agent.acceleration = 50f;
        Debug.Log(transform.name + " :LoadNavMeshAgent",gameObject);
    }
}
