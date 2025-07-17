using System;
using UnityEngine;

public class PlayerSlowShoot : ShootAbstract
{
    private string effectName = nameof(ProjectileCodeName.GunProjectile1);
    protected override void Shooting()
    {
        bool shouldShoot = InputManager.Instance.IsSlowShoot();
        if (!shouldShoot) return;
        
        AttackPoint attackPoint = GetAttackPoint();
        var crosshairTarget = playerCtrl.CrosshairCtrl.GetCrosshair(1).transform;
        SpawnMuzzle(attackPoint.transform.position, crosshairTarget.position);
        EffectCtrl effect = effectSpawner.Spawn(GetEffecct(), attackPoint.transform.position);
        EffectFlyAbstract effectFly = (EffectFlyAbstract)effect;
        effectFly.FlyToTarget.SetTarget(playerCtrl.CrosshairCtrl.GetCrosshair(1).transform);
        effect.gameObject.SetActive(true);
        
        //Debug.Log("PlayerSlowShoot" + attackPoint.transform.position);
    }
    
    protected virtual void SpawnMuzzle(Vector3 spawnPoint, Vector3 rotatorDirection)
    {
        EffectCtrl effect = effectSpawner.PoolPrefabs.GetByName(nameof(MuzzleCodeName.MuzzleGun1));
        EffectCtrl newMuzzle = effectSpawner.Spawn(effect, spawnPoint);
        newMuzzle.transform.forward = rotatorDirection;
        newMuzzle.gameObject.SetActive(true);
    }
    protected virtual EffectCtrl GetEffecct()
    {
        return effectPrefabs.GetByName(effectName);
    }
}
