using System;
using System.Collections;
using UnityEngine;
using UnityEngine.PlayerLoop;
using Update = Unity.VisualScripting.Update;

public class PlayerFastShoot : ShootAbstract
{
    [Header("Shooting Settings")]
    [SerializeField] private float fireRate = 0.1f; // Thời gian giữa các viên đạn
    [SerializeField] private float aimTime = 0.3f; // Thời gian nhắm trước khi bắn
    [SerializeField] private float crosshairDelay = 1f; // Delay ẩn crosshair
    
    [SerializeField] protected bool isShooting = false;
    protected string effectName = "GunBullet";
    
    private float lastShootTime = 0f;
    private Coroutine shootCoroutine;
    private Coroutine hideCrosshairCoroutine;

    protected override void Shooting()
    {
        bool fastShoot = InputManager.Instance.IsFastShoot();
        
        // Bắt đầu bắn
        if (fastShoot && !isShooting)
        {
            StartShooting();
        }
        // Ngừng bắn
        else if (!fastShoot && isShooting)
        {
            StopShooting();
        }
    }

    private void StartShooting()
    {
        isShooting = true;
        
        // Hủy coroutine ẩn crosshair nếu có
        if (hideCrosshairCoroutine != null)
        {
            StopCoroutine(hideCrosshairCoroutine);
            hideCrosshairCoroutine = null;
        }
        
        // Hiện crosshair ngay
        CheckCrosshair(true);
        
        // Bắt đầu bắn
        if (shootCoroutine != null) StopCoroutine(shootCoroutine);
        shootCoroutine = StartCoroutine(ShootSequence());
    }

    private void StopShooting()
    {
        isShooting = false;
        
        // Bắt đầu đếm ngược ẩn crosshair
        if (hideCrosshairCoroutine != null) StopCoroutine(hideCrosshairCoroutine);
        hideCrosshairCoroutine = StartCoroutine(HideCrosshairAfterDelay());
    }

    private IEnumerator ShootSequence()
    {
        // Đợi animation nhắm hoàn thành
        yield return new WaitForSeconds(aimTime);
        
        // Bắn liên tục cho đến khi ngừng
        while (isShooting)
        {
            // Kiểm tra thời gian có thể bắn tiếp không
            if (Time.time >= lastShootTime + fireRate)
            {
                FireBullet();
                lastShootTime = Time.time;
            }
            
            yield return null; // Đợi frame tiếp theo
        }
        
        shootCoroutine = null;
    }

    private IEnumerator HideCrosshairAfterDelay()
    {
        // Đợi delay
        yield return new WaitForSeconds(crosshairDelay);
        
        // Kiểm tra lại xem có đang bắn không
        if (!isShooting)
        {
            CheckCrosshair(false);
        }
        
        hideCrosshairCoroutine = null;
    }

    private void FireBullet()
    {
        AttackPoint attackPoint = GetAttackPoint();
        EffectCtrl effect = effectSpawner.Spawn(GetEffecct(), attackPoint.transform.position);
        EffectFlyAbstract effectFly = (EffectFlyAbstract)effect;
        effectFly.FlyToTarget.SetTarget(playerCtrl.CrosshairCtrl.GetCrosshair(1).transform);
        effect.gameObject.SetActive(true);

        Debug.Log("PlayerFastShoot: " + attackPoint.transform.position);
    }

    protected virtual EffectCtrl GetEffecct()
    {
        return effectPrefabs.GetByName(effectName);
    }
    
    protected virtual void CheckCrosshair(bool isShoot)
    {
        playerCtrl.PlayerActionCtrl.SetShootingMode(isShoot);
    }

    // Cleanup khi object bị hủy
    private void OnDestroy()
    {
        if (shootCoroutine != null) StopCoroutine(shootCoroutine);
        if (hideCrosshairCoroutine != null) StopCoroutine(hideCrosshairCoroutine);
    }
    /*[SerializeField] protected bool isShooting = false;
     protected string effectName = "GunBullet";
    protected override void Shooting()
    {
        bool fastShoot = InputManager.Instance.IsFastShoot();
        CheckCrosshair(fastShoot);
        if (!fastShoot) return;
        
            AttackPoint attackPoint = GetAttackPoint();
            EffectCtrl effect = effectSpawner.Spawn(GetEffecct(), attackPoint.transform.position);
            EffectFlyAbstract effectFly = (EffectFlyAbstract)effect;
            effectFly.FlyToTarget.SetTarget(playerCtrl.CrosshairCtrl.GetCrosshair(1).transform);
            effect.gameObject.SetActive(true);

            Debug.Log("PlayerFastShoot" + attackPoint.transform.position);
            
    }

    protected virtual EffectCtrl GetEffecct()
    {
        return effectPrefabs.GetByName(effectName);
    }
    protected virtual void CheckCrosshair(bool isShoot)
    {
        playerCtrl.PlayerActionCtrl.SetShootingMode(isShoot);
    }*/
    
    
}
