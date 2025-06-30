using System;
using UnityEngine;
using UnityEngine.PlayerLoop;
using Update = Unity.VisualScripting.Update;

public class PlayerFastShoot : ShootAbstract
{
    [SerializeField] protected bool isShooting = false;
    protected virtual void Update()
    {
        Shooting();
        //MoveToShooting();
        
    }
    

    protected override void Shooting()
    {
        bool shouldAim = InputManager.Instance.IsFastShoot();
        if (shouldAim)
        {
            isShooting = true;
            playerCtrl.ThirdPersonCtrl.SetRotateOnMove(false);
            AttackPoint attackPoint = GetAttackPoint();
            //Debug.Log("PlayerFastShoot" + attackPoint.transform.position);
        }
        else
        {
            isShooting = false;
            playerCtrl.ThirdPersonCtrl.SetRotateOnMove(true);
        }
        CheckCrosshair(isShooting);
    }
    
    protected virtual void CheckCrosshair(bool crosshair)
    {
        playerCtrl.PlayerActionCtrl.SetShootingMode(crosshair);
    }
    
    protected virtual void MoveToShooting()
    {
        playerCtrl.PlayerActionCtrl.FaceTarget(isShooting);
    }
    
}
