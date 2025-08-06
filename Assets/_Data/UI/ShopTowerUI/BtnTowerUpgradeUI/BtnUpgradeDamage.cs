using UnityEngine;

public class BtnUpgradeDamage : BtnTowerUpgrade
{
    [SerializeField] protected float damageIncreaseAmount = 1f;
    protected override void DoUpgrade()
    {
        if (currentTower == null) return;
        currentTower.DamageSystem.UpgradeDamage(damageIncreaseAmount);
        
    }
}
