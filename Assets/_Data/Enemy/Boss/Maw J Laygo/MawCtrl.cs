using UnityEngine;

public class MawCtrl : EnemyCtrl
{
    protected override void LoadNavMeshAgent()
    {
        base.LoadNavMeshAgent();
        this.agent.height = 2f;
    }
    public override string GetName()
    {
        return "Enemy";
    }
}
