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
        agent.speed = 4f;
        agent.angularSpeed = 200f;
        agent.acceleration = 50f;
        Debug.Log(transform.name + " :LoadNavMeshAgent",gameObject);
    }
}
