using UnityEngine;
[RequireComponent(typeof(SphereCollider))]
public class EffectDamageSender : DamageSender
{
    [SerializeField]protected SphereCollider sphereCollider;
    [SerializeField]protected EffectCtrl effectCtrlt;

    protected override void SendDamege(DamageRecevier damageRecevier, Collider collider)
    {
        base.SendDamege(damageRecevier, collider);
        effectCtrlt.Despawn.DoDespawn();
    }

    protected override void ConsiderDespawn()
    {
        base.ConsiderDespawn();
        effectCtrlt.Despawn.DoDespawn();
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSphereCollider();
        this.LoadEffectCtrl();
    }
    
    protected virtual void LoadSphereCollider()
    {
        if (sphereCollider != null) return;
        sphereCollider = GetComponent<SphereCollider>();
        sphereCollider.isTrigger = true;
        sphereCollider.radius = 0.025f;
        Debug.Log(transform.name + " :LoadCollider ",gameObject);
    }
    
    protected virtual void LoadEffectCtrl()
    {
        if (effectCtrlt != null) return;
        effectCtrlt = GetComponentInParent<EffectCtrl>();
        Debug.Log(transform.name+ " :LoadEffectCtrl ",gameObject);
    }
    
}
