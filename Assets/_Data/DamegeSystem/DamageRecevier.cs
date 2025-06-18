using UnityEngine;

public abstract class DamageRecevier : MyMonoBehaviour
{
    [SerializeField]protected float maxHp = 100f;
    [SerializeField] protected float currentHp = 100f;
    [SerializeField] protected bool isDead = false;
    [SerializeField]protected bool isImmortal = false;
    public virtual float Deduct(float hp)
    {
        if (!isImmortal ) currentHp -= hp;
        if (IsDead()) OnDead();
        else OnHurt();
        if (currentHp < 0) currentHp = 0;
        
        return currentHp;
    }

    public virtual bool IsDead()
    {
        
        return isDead = this.currentHp <= 0;
    }
    
    protected virtual void OnDead()
    {
       //for override
    }
    
    protected virtual void OnHurt()
    {
        //for override
    }
}
