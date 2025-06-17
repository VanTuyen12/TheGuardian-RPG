using UnityEngine;

public abstract class PoolObj : MyMonoBehaviour
{
    [SerializeField] protected DespawnBase despawn;
    public DespawnBase  Despawn => despawn;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.loadDespawn();
    }

    public abstract string GetName();
    protected virtual void loadDespawn()
    {
        if(this.despawn != null) return;
        despawn = transform.GetComponentInChildren<DespawnBase>();
        Debug.Log(transform.name + " :loadDespawn",gameObject);
    }
}
