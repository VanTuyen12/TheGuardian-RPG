using System;
using UnityEngine;

public abstract class BtnAbstractBuy : ButtonAbstract
{
    [SerializeField]protected GunStandCtrl gunStand;
    [SerializeField]protected TowerCtrl towerPrefab;
    
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadGunStand();
    }
    public TowerCtrl GetTowerPrefabs(TowerCodeName TowerId)
    {
        return TowerSingleton.Instance.Prefabs.PoolPrefabs.GetByName(TowerId.ToString());
    }
    protected virtual void LoadGunStand()
    {
        if (this.gunStand != null) return;
        gunStand = FindAnyObjectByType<GunStandCtrl>();
        Debug.Log(transform.name + " :LoadGunStand", gameObject);
    }
}
