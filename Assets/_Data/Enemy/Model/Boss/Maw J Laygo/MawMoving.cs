using UnityEngine;

public class MawMoving : EnemyMoving
{
    protected override void ResetValue()
    {
        base.ResetValue();
        canMove = true;
    }
}
