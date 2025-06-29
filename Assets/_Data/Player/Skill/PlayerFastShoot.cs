using System;
using UnityEngine;

public class PlayerFastShoot : ShootAbstract
{
    
    protected override void Shooting()
    {

        /*if (!playerCtrl.PlayerAiming.IsAiming)
        {
            bool shouldShoot = InputManager.Instance.IsShooting();
            //bool shouldShoot = InputManager.Instance.IsFastShoot();
            if (!shouldShoot) return;
       
            //if (playerCtrl)
        
            AttackPoint attackPoint = GetAttackPoint();
            Debug.Log("PlayerFastShoot" + attackPoint.transform.position);
            InputManager.Instance.ResetShoot();
        }*/
        
        bool shouldShoot = InputManager.Instance.IsFastShoot();
        if (!shouldShoot) return;
        playerCtrl.PlayerActionCtrl.SetCrosshairState(true);
        AttackPoint attackPoint = GetAttackPoint();
        Debug.Log("PlayerFastShoot" + attackPoint.transform.position);
        InputManager.Instance.ResetShoot();
        
    }
}
