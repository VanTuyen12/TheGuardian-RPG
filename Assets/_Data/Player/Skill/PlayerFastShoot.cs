using System;
using System.Collections;
using UnityEngine;
using UnityEngine.PlayerLoop;
using Update = Unity.VisualScripting.Update;

public class PlayerFastShoot : ShootAbstract
{
    [Header("Shooting Settings")]
    [SerializeField] private float fireRate = 0.07f; // time distance mid
    [SerializeField] private float aimTime = 0.15f; // time aim
    [SerializeField] private float crosshairDelay = 1.5f; // Delay hide crosshair
    
    [SerializeField] protected bool isShooting = false;
    private string effectName = "GunProjectile2";
    
    private float lastShootTime = 0f;
    private Coroutine shootCor;
    private Coroutine hideCrosshair;

    protected override void Shooting()
    {
        bool fastShoot = InputManager.Instance.IsFastShoot();
        
        // start shooting
        if (fastShoot && !isShooting)
        {
            StartShooting();
        }
        // End Shooting
        else if (!fastShoot && isShooting)
        {
            StopShooting();
        }
    }

    private void StartShooting()
    {
        isShooting = true;
        
        // Cancel crosshair
        if (hideCrosshair != null)
        {
            StopCoroutine(hideCrosshair);
            hideCrosshair = null;
        }
        
        CheckCrosshair(true);
        
        // start shooting
        if (shootCor != null) StopCoroutine(shootCor);//check Cancel shooting
        shootCor = StartCoroutine(ShootSequence());
    }

    private void StopShooting()
    {
        isShooting = false;
        
        if (hideCrosshair != null) StopCoroutine(hideCrosshair);
        hideCrosshair = StartCoroutine(HideCrosshairAfterDelay());
    }

    private IEnumerator ShootSequence()
    {
        yield return new WaitForSeconds(aimTime);
        
        // Shooting
        while (isShooting)
        {
            // check shooting 
            if (Time.time >= lastShootTime + fireRate)
            {
                ShootBullet();
                lastShootTime = Time.time;
            }
            
            yield return null;
        }
        shootCor = null;
    }
    private void ShootBullet()
    {
        AttackPoint attackPoint = GetAttackPoint();
        var crosshairTarget = playerCtrl.CrosshairCtrl.GetCrosshair(1).transform;
        
        EffectCtrl effect = effectSpawner.Spawn(GetEffecct(), attackPoint.transform.position);
        EffectFlyAbstract effectFly = (EffectFlyAbstract)effect;
        effectFly.FlyToTarget.SetTarget(crosshairTarget);
        effect.gameObject.SetActive(true);

        //Debug.Log("PlayerFastShoot: " + attackPoint.transform.position);
    }
    private IEnumerator HideCrosshairAfterDelay()
    {
        // Đợi delay
        yield return new WaitForSeconds(crosshairDelay);
        
        //check shooting
        if (!isShooting)
        {
            CheckCrosshair(false);
        }
        
        hideCrosshair = null;
    }
    protected virtual EffectCtrl GetEffecct()
    {
        return effectPrefabs.GetByName(effectName);
    }
    
    protected virtual void CheckCrosshair(bool isShoot)
    {
        playerCtrl.PlayerActionCtrl.SetShootingMode(isShoot);
    }

    // Cleanup object Destroy
    private void OnDestroy()
    {
        if (shootCor != null) StopCoroutine(shootCor);
        if (hideCrosshair != null) StopCoroutine(hideCrosshair);
    }
}
