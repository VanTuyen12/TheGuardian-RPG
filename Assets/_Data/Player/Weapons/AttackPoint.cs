using UnityEngine;

public class AttackPoint : MyMonoBehaviour
{
    protected override void Reset()
    {
        base.Reset();
        transform.localPosition = new Vector3(0,0,0.16f);
    }
}
