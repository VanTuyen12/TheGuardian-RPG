using System;
using UnityEngine;

public class GameEvent : MyMonoBehaviour
{
    public static event Action<bool> OnSpawning;
    public static event Action<bool,GameObject> OnTowerCollider;
    public static event Action<bool> OnEnemyReachEnd;
    public static void TriggerEnemyEndPoint(bool isColliding)
    {
        OnEnemyReachEnd?.Invoke(isColliding);
    }
    
    public static void CheckTimerSpawn(bool spawn)
    {
        OnSpawning?.Invoke(spawn);
    }

    public static void TriggerTowerCollider(bool isColliding, GameObject pointTower)
    {
        OnTowerCollider?.Invoke(isColliding, pointTower);
    }

    
}
