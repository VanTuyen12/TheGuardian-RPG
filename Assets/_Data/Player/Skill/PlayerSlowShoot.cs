using System;
using UnityEngine;

public class PlayerSlowShoot : ShootAbstract
{
    private void Update()
    {
        Shooting();
    }

    protected override void Shooting()
    {
        /*if (playerCtrl.PlayerAiming.IsAiming)
        {
            //bool shouldShoot = InputManager.Instance.IsSlowShoot();
            bool shouldShoot = InputManager.Instance.IsShooting();
            if (!shouldShoot) return;
                AttackPoint attackPoint = GetAttackPoint();
                Debug.Log("PlayerSlowShoot" + attackPoint.transform.position);
                InputManager.Instance.ResetShoot();
        }*/
        
        bool shouldShoot = InputManager.Instance.IsSlowShoot();
        if (!shouldShoot) return;
        
        AttackPoint attackPoint = GetAttackPoint();
        Debug.Log("shouldShoot: " + shouldShoot);
        Debug.Log("PlayerSlowShoot" + attackPoint.transform.position);
        
    }
}
