using System;
using UnityEngine;
using UnityEngine.PlayerLoop;
using Update = Unity.VisualScripting.Update;

public class PlayerFastShoot : ShootAbstract
{
    
    [SerializeField] protected bool isShooting = false;
     string effectName = "GunBullet";
    protected override void Shooting()
    {
        bool shouldAim = InputManager.Instance.IsFastShoot();
        if (shouldAim)
        {
            isShooting = true;
            playerCtrl.ThirdPersonCtrl.SetRotateOnMove(false);
            AttackPoint attackPoint = GetAttackPoint();
            EffectCtrl effect = effectSpawner.Spawn(GetEffecct(), attackPoint.transform.position);
            
            EffectFlyAbstract effectFly = (EffectFlyAbstract) effect;
            
            
            effect.gameObject.SetActive(true);
            //Debug.Log("PlayerFastShoot" + attackPoint.transform.position);
        }
        else
        {
            isShooting = false;
            playerCtrl.ThirdPersonCtrl.SetRotateOnMove(true);
        }
        CheckCrosshair();
    }

    protected virtual EffectCtrl GetEffecct()
    {
        return effectPrefabs.GetByName(effectName);
    }
    protected virtual void CheckCrosshair()
    {
        playerCtrl.PlayerActionCtrl.SetShootingMode(isShooting);
    }
    
    
}
