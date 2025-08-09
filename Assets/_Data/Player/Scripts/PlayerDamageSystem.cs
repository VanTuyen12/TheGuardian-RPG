using UnityEngine;
using UnityEngine.Serialization;

public class PlayerDamageSystem : MyMonoBehaviour
{
    [SerializeField] protected float baseDamageSkillFast = 5f;
    [SerializeField] protected float baseDamageSkillSlow= 15f;
    [SerializeField] protected float damageSkillFast;
    [SerializeField] protected float damageSkillSlow;

    protected virtual void OnEnable()
    {
        ResetDamage();
    }
    
    public virtual void ResetDamage()
    {
        damageSkillFast = baseDamageSkillFast;
        damageSkillSlow = baseDamageSkillSlow;
    }
    
    public virtual void UpgradeDamageFast(float amount)
    {
        damageSkillFast += amount;
    }
    public virtual void UpgradeDamageSlow(float amount)
    {
        damageSkillSlow += amount;
    }
    public virtual float GetDamageFast()
    {
        return damageSkillFast;
    }
    public virtual float GetDamageSlow()
    {
        return damageSkillSlow;
    }
    public virtual void SetBaseDamageFast(float damage)
    {
        baseDamageSkillFast = damage;
        damageSkillFast = damage;
    }
    public virtual void SetBaseDamageSlow(float damage)
    {
        baseDamageSkillSlow = damage;
        damageSkillSlow = damage;
    }
}
