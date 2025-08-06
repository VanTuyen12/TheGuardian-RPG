using System;
using UnityEngine;

public class TowerDamageSystem : TowerAbstract
{
    [SerializeField] protected float baseDamage = 50f;
    [SerializeField] protected float currentDamage;

    protected virtual void OnEnable()
    {
        ResetDamage();
    }
    
    public virtual void ResetDamage()
    {
        currentDamage = baseDamage;
    }
    
    public virtual void UpgradeDamage(float amount)
    {
        currentDamage += amount;
    }
    
    public virtual float GetCurrentDamage()
    {
        return currentDamage;
    }
    
    public virtual void SetBaseDamage(float damage)
    {
        baseDamage = damage;
        currentDamage = damage;
    }
}

