using System;
using UnityEngine;

public class PlayerFastShoot : ShootAbstract
{
    
    protected override void Shooting()
    {
        bool shouldShoot = InputManager.Instance.IsShooting();
        if (!shouldShoot) return;
            AttackPoint attackPoint = GetAttackPoint();
            Debug.Log("Shootingggg" + attackPoint.transform.position);
            
        
    }
}
