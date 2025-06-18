using UnityEngine;

public class MawMoving : EnemyMoving
{
    protected override void ResetValue()
    {
        base.ResetValue();
        this.pathName = "Path_1";
    }
}
