using System;
using UnityEngine;

public class PlayerSlowShoot : ShootAbstract
{
    private string effectName = "GunBulletAim";
    protected override void Shooting()
    {
        bool shouldShoot = InputManager.Instance.IsSlowShoot();
        if (!shouldShoot) return;
        
        AttackPoint attackPoint = GetAttackPoint();
        EffectCtrl effect = effectSpawner.Spawn(GetEffecct(), attackPoint.transform.position);
        EffectFlyAbstract effectFly = (EffectFlyAbstract)effect;
        effectFly.FlyToTarget.SetTarget(playerCtrl.CrosshairCtrl.GetCrosshair(1).transform);
        effect.gameObject.SetActive(true);
        
        //Debug.Log("PlayerSlowShoot" + attackPoint.transform.position);
    }
    protected virtual EffectCtrl GetEffecct()
    {
        return effectPrefabs.GetByName(effectName);
    }
}
