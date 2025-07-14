using UnityEngine;
[RequireComponent(typeof(SphereCollider))]
public abstract class EffectDamageSender : DamageSender
{
    [SerializeField]protected SphereCollider sphereCollider;
    [SerializeField]protected EffectCtrl effectCtrl;
    [SerializeField]protected EffectSpawner effectSpawner;

    protected override void SendDamege(DamageRecevier damageRecevier, Collider collider)
    {
        base.SendDamege(damageRecevier, collider);
        this.ShowHitEffect(collider);
        effectCtrl.Despawn.DoDespawn();
    }

    protected virtual void ShowHitEffect(Collider collider)
    {
        var hitPoin =  collider.ClosestPoint(transform.position);
        EffectCtrl prefab = effectSpawner.PoolPrefabs.GetByName(GetHitName());
        EffectCtrl newObj = effectSpawner.Spawn(prefab, hitPoin);
        newObj.gameObject.SetActive(true);
    }

    protected abstract string GetHitName();
    
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSphereCollider();
        this.LoadEffectCtrl();
        this.LoadEffectSpawner();
    }
    protected virtual void LoadEffectSpawner()
    {
        if (effectSpawner != null) return;
        effectSpawner = GameObject.Find("EffectSpawner").GetComponent<EffectSpawner>();
        Debug.Log(transform.name+ " :LoadEffectSpawner ",gameObject);
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
        if (effectCtrl != null) return;
        effectCtrl = GetComponentInParent<EffectCtrl>();
        Debug.Log(transform.name+ " :LoadEffectCtrl ",gameObject);
    }
    
}
