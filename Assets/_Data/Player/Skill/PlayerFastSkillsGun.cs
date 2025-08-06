using System;
using System.Collections;
using UnityEngine;
using UnityEngine.PlayerLoop;
using Update = Unity.VisualScripting.Update;

public class PlayerFastSkillsGun : SkillsGunAbstract
{
    [Header("Shooting Settings")]
    [SerializeField] private float fireRate = 0.07f; // time distance mid
    [SerializeField] private float aimTime = 0.15f; // time aim
    [SerializeField] private float crosshairDelay = 1.5f; // Delay hide crosshair
    
    [SerializeField] protected bool isShooting = false;
    private string effectName = nameof(ProjectileCodeName.GunProjectile2);
    private ItemCode bulletItem = ItemCode.Bullet1;
    private SoundName soundName = SoundName.FastShot;
    private int bulletAmount = 1;
    
    
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
        
        this.SpawnEffect(effectName,bulletItem, bulletAmount,soundName);
    }
    protected override float GetDamageEffect()
    {
        return playerCtrl.DamageSystem.GetDamageFast();
    }
    private IEnumerator HideCrosshairAfterDelay()
    {
        
        yield return new WaitForSeconds(crosshairDelay);
        
        //check shooting
        if (!isShooting)
        {
            CheckCrosshair(false);
        }
        
        hideCrosshair = null;
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
