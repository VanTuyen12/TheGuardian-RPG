using UnityEngine;

public class Swarm08Ctrl : EnemyCtrl
{
    protected override void LoadNavMeshAgent()
    {
        base.LoadNavMeshAgent();
        agent.height = 1f;
    }
    

    public override string GetName()
    {
        return "Enemy";
    }
}
