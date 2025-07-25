using System;
using UnityEngine;

public class GameEvent : MyMonoBehaviour
{
    public static event Action<bool,GameObject> OnTowerCollider;

    public static void TriggerTowerCollider(bool isColliding, GameObject pointTower)
    {
        OnTowerCollider?.Invoke(isColliding, pointTower);
    }
}
