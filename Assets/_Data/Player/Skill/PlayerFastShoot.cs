using System;
using UnityEngine;
using UnityEngine.PlayerLoop;
using Update = Unity.VisualScripting.Update;

public class PlayerFastShoot : ShootAbstract
{
    private bool wasShootingLastFrame = false;
    protected virtual void Update()
    {
        bool isHoldingShoot  = InputManager.Instance.IsShooting();
            FaceTargetToShooting(isHoldingShoot);
            UpdateRigAndLayer(isHoldingShoot);
            CheckCrosshair(isHoldingShoot);
        
        Shooting();
        
    }

    private void FixedUpdate()
    {
        CheckStopShoot();
    }

    protected override void Shooting()
    {
        bool shouldShoot = InputManager.Instance.IsFastShoot();
        if (!shouldShoot)
        {
            isShooting = false;
            return; 
        } 
        
        /*isShooting = true;
        CheckCrosshair(true);
        AttackPoint attackPoint = GetAttackPoint();
        Debug.Log("PlayerFastShoot" + attackPoint.transform.position);
        InputManager.Instance.ResetShoot();*/
        // Chỉ bắn khi mới bắt đầu nhấn (edge detection)
        if (!wasShootingLastFrame && shouldShoot)
        {
            isShooting = true;
            CheckCrosshair(true);
            
            AttackPoint attackPoint = GetAttackPoint();
            Debug.Log("PlayerFastShoot" + attackPoint.transform.position);
            
            // Reset input sau khi đã xử lý
            InputManager.Instance.ResetShoot();
        }
        
        
        wasShootingLastFrame = shouldShoot;
    }

    protected virtual bool InputCheck()
    {
        return InputManager.Instance.IsFastShoot();
    }
    
    public virtual void CheckStopShoot()
    {
        if (isShooting) {
           
            shotTimer = 0f;
            isattacking = true;
        }
        else {
            if (!isattacking) return;
            shotTimer += Time.deltaTime;
                
            if (!(shotTimer > ceasefireTime)) return;
            isattacking = false;
            //CheckCrosshair(false);
            //FaceTargetToShooting(false);
            shotTimer = 0f;
        }
    }
    protected virtual void CheckCrosshair(bool crosshair)
    {
        playerCtrl.PlayerActionCtrl.SetCrosshairState(crosshair);
    }
    
    protected virtual void FaceTargetToShooting(bool isattacking)
    {
        playerCtrl.PlayerActionCtrl.FaceTarget(playerCtrl.CrosshairCtrl.GetCrosshair(1), isattacking);
    }
    protected virtual void UpdateRigAndLayer(bool isattacking)
    {
        playerCtrl.PlayerActionCtrl.UpdateRigAndLayer( isattacking);
    }
    
    
    
}
