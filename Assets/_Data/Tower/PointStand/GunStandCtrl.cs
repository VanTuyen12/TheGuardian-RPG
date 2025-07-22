using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class GunStandCtrl : MyMonoBehaviour
{
    [SerializeField]protected SphereCollider collider;
    [SerializeField]protected PointStand point;
    public PointStand Point => point;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSphereCollider();
        this.LoadPointStand();
    }
    protected virtual void LoadPointStand()
    {
        if (point!= null) return;
        point = GetComponentInChildren<PointStand>();
        Debug.Log(transform.name + " :LoadPointStand ",gameObject);
    }
    protected virtual void LoadSphereCollider()
    {
        if (collider!= null) return;
        collider = GetComponent<SphereCollider>();
        collider.radius = 3f;
        collider.isTrigger = true;
        Debug.Log(transform.name + " :LoadSphereCollider ",gameObject);
    }
}
