using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public abstract class EffectFlyAbstract : EffectCtrl
{
    //for shooting straight bullets
    [SerializeField] protected Rigidbody rb;
    [SerializeField]protected FlyToTarget flyToTarget;
    public FlyToTarget FlyToTarget => flyToTarget;
    [SerializeField]protected DamageSender damageSender;
    public DamageSender DamageSender => damageSender;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadFlyToTarget();
        this.LoadRigidbody();
        this.LoadDamageSender();
    }
    protected virtual void LoadDamageSender()
    {
        if(damageSender != null) return;
        damageSender = GetComponentInChildren<DamageSender>();
        Debug.Log(transform.name + " :LoadDamageSender",gameObject);
    }
    protected virtual void LoadRigidbody()
    {
        if (rb != null) return;
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
        rb.freezeRotation = true;
        rb.linearDamping = 0;
        Debug.Log(transform.name+" :LoadRigidbody ",gameObject);
    }
    protected virtual void LoadFlyToTarget()
    {
       if(flyToTarget != null) return;
       flyToTarget = GetComponentInChildren<FlyToTarget>();
       Debug.Log(transform.name + " :LoadFlyToTarget",gameObject);
    }
}
