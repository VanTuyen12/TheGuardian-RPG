using UnityEngine;

[RequireComponent(typeof(Terrain))]
public class TerrainCollider : DamageRecevier
{
    [SerializeField] protected Terrain terrainCollider;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadBoxCollider();
    }

    protected virtual void LoadBoxCollider()
    {
        if(terrainCollider != null) return;
        terrainCollider = GetComponent<Terrain>();
        //terrainCollider.;
        Debug.Log(transform.name + " has loaded WallDamageReceiver component");
    }

    protected override void ResetValue()
    {
        base.ResetValue();
        this.isImmortal = true;
    }
}
