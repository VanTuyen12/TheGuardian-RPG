using UnityEngine;

public class Swarm08Ctrl : EnemyCtrl
{
    protected override void LoadNavMeshAgent()
    {
        base.LoadNavMeshAgent();
        agent.height = 1f;
    }
    
    protected override void LoadEnemyTargetable()
    {
        base.LoadEnemyTargetable();
        enemyTargetable.transform.localPosition = new Vector3(0f, 0.1f, 0f);
    }

    public override string GetName()
    {
        return "Enemy";
    }
}
