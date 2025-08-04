using System;
using UnityEngine;

public class PlayerSlowSkillsGun : SkillsGunAbstract
{
    private string effectName = nameof(ProjectileCodeName.GunProjectile1);
    private ItemCode bulletItem = ItemCode.Bullet2;
    private SoundName soundName = SoundName.SlowShot;
    private int bulletAmount = 1;
    protected override void Shooting()
    {
        bool shouldShoot = InputManager.Instance.IsSlowShoot();
        if (!shouldShoot) return;
        
        this.SpawnEffect(effectName,bulletItem, bulletAmount,soundName);
        //Debug.Log("PlayerSlowShoot" + attackPoint.transform.position);
    }
    protected virtual EffectCtrl GetEffecct()
    {
        return effectPrefabs.GetByName(effectName);
    }
}
