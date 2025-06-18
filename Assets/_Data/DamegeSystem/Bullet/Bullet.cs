using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Bullet : PoolObj
{
    [SerializeField] protected Rigidbody rb;
    
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadRigidbody();
    }
    
    public override string GetName()
    {
        return "Bullet";
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
}
