using UnityEngine;
using UnityEngine.AI;

public class EnemyCtrl : MyMonoBehaviour
{
    [SerializeField]protected NavMeshAgent agent;
    public NavMeshAgent Agent => agent;
    
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadNavMeshAgent();
    }
    
    protected virtual void LoadNavMeshAgent()
    {
        if(agent != null) return;
        agent = GetComponent<NavMeshAgent>();
        
        Debug.Log(transform.name + " :LoadNavMeshAgent",gameObject);
    }
}
