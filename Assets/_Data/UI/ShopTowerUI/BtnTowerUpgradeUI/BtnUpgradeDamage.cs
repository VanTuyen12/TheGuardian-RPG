using UnityEngine;

public class BtnUpgradeDamage : BtnTowerUpgrade
{
    [SerializeField] protected float damageIncreaseAmount = 1f;
    protected override void DoUpgrade()
    {
        if (currentTower == null) return;
        EffectFlyAbstract effectFly = currentTower.TowerShooting.Projectile as EffectFlyAbstract;
        
        if (effectFly == null) return;
        DamageSender damageSender = effectFly.DamageSender;
        
        if (damageSender == null) return;
        float currentDamage = damageSender.Damage;
        float newDamage = currentDamage + damageIncreaseAmount;
        damageSender.SetDamage(newDamage);
            
        Debug.Log($"Upgraded {currentTower.name} damage from {currentDamage} to {newDamage}");
    }
}
