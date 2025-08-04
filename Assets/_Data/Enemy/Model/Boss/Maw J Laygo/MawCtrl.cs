using UnityEngine;

public class MawCtrl : EnemyBossCtrl
{
    protected override void LoadNavMeshAgent()
    {
        base.LoadNavMeshAgent();
        this.agent.height = 2f;
    }

    protected override void LoadEnemyTargetable()
    {
        base.LoadEnemyTargetable();
        enemyTargetable.transform.localPosition = new Vector3(0f, 1f, 0f);
    }

    public override string GetName()
    {
        return nameof(EnemyCodeName.MawJLaygo);
    }
}
