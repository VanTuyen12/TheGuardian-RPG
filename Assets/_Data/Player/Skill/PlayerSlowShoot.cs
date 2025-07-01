using System;
using UnityEngine;

public class PlayerSlowShoot : ShootAbstract
{

    protected override void Shooting()
    {
        bool shouldShoot = InputManager.Instance.IsSlowShoot();
        if (!shouldShoot) return;
        
        AttackPoint attackPoint = GetAttackPoint();
        Debug.Log("shouldShoot: " + shouldShoot);
        Debug.Log("PlayerSlowShoot" + attackPoint.transform.position);
        
    }
}
