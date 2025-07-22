using UnityEngine;
using UnityEngine.Serialization;

public class TowerSingleton : Singleton<TowerSingleton>
{
   [SerializeField] protected TowerSpawner prefabs;
    public TowerSpawner Prefabs => prefabs;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadTowerSpawner();
    }

    protected virtual void LoadTowerSpawner()
    {
        if (this.prefabs != null) return;
        prefabs = GetComponent<TowerSpawner>();
        Debug.Log(transform.name + " :LoadTowerSpawner", gameObject);
    }
}