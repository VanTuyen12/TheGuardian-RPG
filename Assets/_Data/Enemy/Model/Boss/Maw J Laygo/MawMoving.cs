using UnityEngine;

public class MawMoving : EnemyMoving
{
    protected override void ResetValue()
    {
        base.ResetValue();
        this.pathName = nameof(EnemyCodePath.Path_1);
        canMove = true;
    }
}
