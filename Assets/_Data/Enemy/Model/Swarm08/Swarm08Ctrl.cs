using UnityEngine;

public class Swarm08Ctrl : EnemyNormalCtrl
{
    protected override void LoadNavMeshAgent()
    {
        base.LoadNavMeshAgent();
        agent.height = 1f;
    }
    

    public override string GetName()
    {
        return nameof(EnemyCodeName.Swarm08);
    }
}
