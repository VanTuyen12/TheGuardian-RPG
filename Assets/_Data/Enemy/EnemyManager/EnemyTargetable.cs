using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class EnemyTargetable : MyMonoBehaviour
{
    [SerializeField]protected SphereCollider sphereCollider;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSphereCollider();
    }

    protected virtual void LoadSphereCollider()
    {
        if (this.sphereCollider != null) return;
        this.sphereCollider = this.GetComponent<SphereCollider>();
        sphereCollider.isTrigger = true;
        sphereCollider.radius = 0.35f;
        Debug.Log(transform.name + " LoadSphereCollider",gameObject);
    }
}
