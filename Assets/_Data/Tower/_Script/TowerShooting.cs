using System;
using Unity.VisualScripting;
using UnityEngine;

public class TowerShooting : TowerAbstract
{
    [SerializeField] protected EnemyCtrl target;
    [SerializeField] protected EffectSpawner effectSpawner;
    
    [Header("Setting Tower")]
    [SerializeField] private float rotationSpeed = 5f;
    [SerializeField] private float shootSpeed = 1f;
    [SerializeField] private float targetLoadSpeed = 1f;
    [SerializeField] private int currentFirePoint = 0;
    
    [Header("Kill")]
    [SerializeField] private int totalKill = 0;
    [SerializeField] private int killCount = 0;
    public int KillCount => killCount;
    

    protected override void Start()
    {
        base.Start();
        Invoke(nameof(this.TargetLoading),this.targetLoadSpeed);
        Invoke(nameof(this.Shooting),this.shootSpeed);
    }

    protected void FixedUpdate()
    {
        this.Looking();
        this.IsTargetDead();
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadEffectSpawer();
    }

    protected virtual void LoadEffectSpawer()
    {
        if(this.effectSpawner != null) return;
        effectSpawner =GameObject.Find("EffectSpawner").GetComponent<EffectSpawner>();
        Debug.Log(transform.name + " :LoadEffectSpawer",gameObject);
    }

    public virtual bool DeductKillCount(int count)
    {
        if(this.killCount < count ) return false;
        this.killCount -= count;
        return true;
    }
    
    protected virtual bool IsTargetDead()
    {
        if (this.target == null) return true;
        if (!target.DamageRecevier.IsDead()) return false;
        this.killCount++;
        this.totalKill++;
        this.target = null;
        
        return true;
    }
    
    protected virtual void TargetLoading()
    {
        Invoke(nameof(this.TargetLoading),this.targetLoadSpeed);
        this.target = this.towerCtrl.TowerTargeting.Nearest;
    }
    
    protected virtual void Looking()
    {
        if (this.target == null) return;
        
        Vector3 targetPosition = target.EnemyTargetable.transform.position;
        RotateTowerModel(targetPosition);
        RotateTowerRotation(targetPosition);
    }
    
    protected virtual void RotateTowerModel(Vector3 targetPosition) //Rotate Model along Y axis (left/right)
    {
        Vector3 directionY = targetPosition - towerCtrl.Model.transform.position;
        directionY.y = 0; // Remove Y => rotate horizontally 
        if (directionY != Vector3.zero)
        {
            //towerCtrl.Model.transform.rotation = Quaternion.LookRotation(directionY);
            
            Quaternion targetRotation = Quaternion.LookRotation(directionY);
            towerCtrl.Model.transform.rotation = Quaternion.Slerp(
                towerCtrl.Model.transform.rotation, 
                targetRotation, 
                rotationSpeed * Time.fixedDeltaTime
            );
        }
    }
    
    protected virtual void RotateTowerRotation(Vector3 targetPosition)  // Rotation along the X axis (up/down)
    {
        Transform rotationPart = towerCtrl.Rotation.transform;
        if (rotationPart == null) return;
        
        Vector3 directionX = targetPosition - rotationPart.position;
        float angle = Mathf.Atan2(directionX.y, directionX.magnitude) * Mathf.Rad2Deg;//calculate rotation in radians => sang do
        
        Quaternion targetRotation = Quaternion.Euler(-angle, 0, 0);
        rotationPart.localRotation = Quaternion.Lerp(
            rotationPart.localRotation,
            targetRotation,
            Time.fixedDeltaTime * rotationSpeed);
    }

    
    protected virtual void Shooting()
    {
        Invoke(nameof(this.Shooting),this.shootSpeed);
        if (this.target == null) return;
        FirePoint firePoint = GetFirePoint();
        Vector3 rotatorDirection = towerCtrl.Rotation.transform.forward;
        
        this.SpawnBullet(firePoint.transform.position,rotatorDirection);
        this.SpawnMuzzle(firePoint.transform.position,rotatorDirection);
    }
    
    protected virtual void SpawnBullet(Vector3 spawnPoint,Vector3 rotatorDirection )
    {
        EffectCtrl effect = effectSpawner.PoolPrefabs.GetByName(nameof(ProjectileCodeName.TowerProjectile1));
        EffectCtrl newProjectile = effectSpawner.Spawn(effect, spawnPoint);
        newProjectile.transform.forward = rotatorDirection;
        
        EffectFlyAbstract effectFly = newProjectile as EffectFlyAbstract;
        effectFly.FlyToTarget.SetTarget(target.EnemyTargetable.transform);
        
        newProjectile.gameObject.SetActive(true);
    }
    protected virtual void SpawnMuzzle(Vector3 spawnPoint, Vector3 rotatorDirection)
    {
        EffectCtrl effect = effectSpawner.PoolPrefabs.GetByName(nameof(MuzzleCodeName.MuzzleTower1));
        EffectCtrl newMuzzle = effectSpawner.Spawn(effect, spawnPoint);
        newMuzzle.transform.forward = rotatorDirection;
        newMuzzle.gameObject.SetActive(true);
    }
    protected virtual FirePoint GetFirePoint()
    {
        FirePoint firePoint = towerCtrl.FirePoint[currentFirePoint];
        currentFirePoint++;
        if (currentFirePoint == towerCtrl.FirePoint.Count) currentFirePoint = 0;
        return firePoint;
    }
}
