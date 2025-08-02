using System;
using UnityEngine;

public class PlayerSlowSkills : SkillsAbstract
{
    private string effectName = nameof(ProjectileCodeName.GunProjectile1);
    protected override void Shooting()
    {
        bool shouldShoot = InputManager.Instance.IsSlowShoot();
        if (!shouldShoot) return;
        
        this.SpawnEffect(GetEffecct());
        this.SpawnSoundSfx(SoundName.SlowShot);
        //Debug.Log("PlayerSlowShoot" + attackPoint.transform.position);
    }
    protected virtual EffectCtrl GetEffecct()
    {
        return effectPrefabs.GetByName(effectName);
    }
}
