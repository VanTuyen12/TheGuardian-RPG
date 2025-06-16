using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Bullet : MyMonoBehaviour
{
    [SerializeField] protected Rigidbody rb;
    [SerializeField] protected BulletDespawn despawn;
    public BulletDespawn  Despawn => despawn;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadRigidbody();
        this.loadDespawn();
    }
    protected virtual void loadDespawn()
    {
        if(this.despawn != null) return;
        despawn = GetComponentInChildren<BulletDespawn>();
        Debug.Log(transform.name + " :loadDespawn",gameObject);
    }
    protected virtual void LoadRigidbody()
    {
        if (rb != null) return;
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
        rb.freezeRotation = true;
        rb.linearDamping = 0;
    }
}
