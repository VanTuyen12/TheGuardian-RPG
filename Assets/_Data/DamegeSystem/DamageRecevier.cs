using UnityEngine;

public abstract class DamageRecevier : MyMonoBehaviour
{
    [SerializeField]protected float maxHp = 100f;
    [SerializeField] protected float currentHp = 100f;
    [SerializeField] protected bool isDead = false;

    public virtual float Deduct(float hp)
    {
        currentHp -= hp;
        if (IsDead())
        {
            OnDead();
        }
        
        if (currentHp < 0) currentHp = 0;
        
        return currentHp;
    }

    protected virtual bool IsDead()
    {
        
        return isDead = this.currentHp <= 0;
    }
    
    protected virtual void OnDead()
    {
       //for override
    }
}
