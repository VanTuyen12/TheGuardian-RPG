using UnityEngine;


public abstract class DamageSender : MyMonoBehaviour
{
    [SerializeField]protected float damage = 10f;
    public float Damage => damage;

    public virtual void SetDamage(float damage)
    {
        this.damage = damage;
    }
    protected virtual void OnTriggerEnter(Collider collider)
    {   
        DamageRecevier damageRecevier = collider.GetComponent<DamageRecevier>();
        if (damageRecevier == null) return; 
        this.SendDamege(damageRecevier,collider);
        // Debug.Log(" :OnTriggerEnter "+ collider.name);
    }
    
    protected virtual void SendDamege(DamageRecevier damageRecevier,Collider collider)
    {
        damageRecevier.Deduct(damage);
    }
}
