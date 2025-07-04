using UnityEngine;

public class TerrainDamagaRecevier : DamageRecevier
{
    [SerializeField] protected TerrainCollider terrainCollider;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadBoxCollider();
    }

    protected virtual void LoadBoxCollider()
    {
        if(terrainCollider != null) return;
        terrainCollider = GetComponent<TerrainCollider>();
        //terrainCollider.;
        Debug.Log(transform.name + " has loaded WallDamageReceiver component");
    }

    protected override void ResetValue()
    {
        base.ResetValue();
        this.isImmortal = true;
    }
}
