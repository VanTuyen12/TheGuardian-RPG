using System;
using UnityEngine;

public class EndPoint : MyMonoBehaviour
{
    protected virtual void OnTriggerEnter(Collider collider)
    {
        if (collider.name != Const.TARGETABLES) return;
        Debug.Log("LOSE GAME");
        GameEvent.TriggerEnemyEndPoint(true);
            
    }
    
}
