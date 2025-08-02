using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class TowerStandCtrl : MyMonoBehaviour
{
    [SerializeField]protected new SphereCollider collider;
    [SerializeField]protected PointStand point;
    public PointStand Point => point;
    [SerializeField]protected TowerCtrl towerPrefab;
    public TowerCtrl TowerPrefab => towerPrefab;
    [SerializeField]protected TowerStandUIManager uiManager;
    
    private Dictionary<TowerCodeName, TowerState> towerStates;
    
    protected override void Awake()
    {
        base.Awake();
        towerStates = new Dictionary<TowerCodeName, TowerState>
        {
            { TowerCodeName.NoName, new TowerState(TowerCodeName.NoName) },
            { TowerCodeName.MachineGunLv1, new TowerState(TowerCodeName.MachineGunLv1) },
            { TowerCodeName.MachineGunLv2, new TowerState(TowerCodeName.MachineGunLv2) },
            { TowerCodeName.MachineGunLv3, new TowerState(TowerCodeName.MachineGunLv3) },
            { TowerCodeName.MachineGunLv5, new TowerState(TowerCodeName.MachineGunLv5) },
        };
    }

    public bool CanBuyTower(TowerCodeName towerType)
    {
        return !towerStates[towerType].IsBought;
    }

    public void BuyTower(TowerCodeName towerType)
    {
        if (CanBuyTower(towerType))
        {
            towerStates[towerType].IsBought = true;
            UpdateBuyTower(towerType);
        }
    }

    public bool IsTowerBought(TowerCodeName towerType)
    {
        return towerStates[towerType].IsBought;
    }
    
    public virtual void UpdateBuyTower(TowerCodeName newTowerType)
    {
        if (towerPrefab != null) ResetTower();

        SpawnTower(newTowerType);
    }

    protected virtual void SpawnTower(TowerCodeName newTowerType)
    {
        Vector3 prefabPos = point.transform.position;
        towerPrefab = TowerSingleton.Instance.Prefabs.Spawn( GetTowerPrefabs(newTowerType), prefabPos);
        towerPrefab.SetActive(true);
    }
    public TowerCtrl GetTowerPrefabs(TowerCodeName TowerId)
    {
        return TowerSingleton.Instance.Prefabs.PoolPrefabs.GetByName(TowerId.ToString());
    }

    protected virtual void ResetTower()
    {
        towerPrefab.Level.SetSkillScore(1);
        towerPrefab.Level.SetCurrentLevel(1);
        DespawnBuyTower(towerPrefab);
    }
    protected virtual void DespawnBuyTower(TowerCtrl obj)
    {
        TowerSingleton.Instance.Prefabs.Despawn(obj);
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSphereCollider();
        this.LoadPointStand();
        this.LoadTowerStandUIManager();
    }
    protected virtual void LoadPointStand()
    {
        if (point!= null) return;
        point = GetComponentInChildren<PointStand>();
        Debug.Log(transform.name + " :LoadPointStand ",gameObject);
    }
    protected virtual void LoadTowerStandUIManager()
    {
        if (uiManager!= null) return;
        uiManager = GetComponentInChildren<TowerStandUIManager>();
        Debug.Log(transform.name + " :LoadTowerStandUIManager ",gameObject);
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
