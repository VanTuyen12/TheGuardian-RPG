using UnityEngine;

public class BtnUpgradeSpeed : BtnTowerUpgrade
{
    [SerializeField] protected float speedIncreaseAmount = 0.1f;
    [SerializeField] protected float maxSpeed = 0.1f;
    
    protected override void DoUpgrade()
    {
        if (currentTower == null) return;
        TowerShooting towerShooting = currentTower.TowerShooting;
        
        if (towerShooting == null) return;
        
        float currentSpeed = towerShooting.ShootSpeed;
        float newSpeed = currentSpeed - speedIncreaseAmount;
        if (newSpeed < maxSpeed) newSpeed = maxSpeed;
            
        towerShooting.SetShootSpeed(newSpeed);
            
        Debug.Log($"Upgraded {currentTower.name} shoot speed to {newSpeed}");
    }
}
