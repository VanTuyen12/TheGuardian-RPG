using System;
using UnityEngine;
using UnityEngine.Serialization;

public class TowerManager : Singleton<TowerManager>
{
    [SerializeField]protected TowerCodeName newTowerId = TowerCodeName.NoName;
    public TowerCodeName NewTowerId => newTowerId;
    [SerializeField]protected GunStandCtrl gunStand;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadGunStand();
    }

    protected virtual void LoadGunStand()
    {
        if (this.gunStand != null) return;
        gunStand = FindAnyObjectByType<GunStandCtrl>();
        Debug.Log(transform.name + " :LoadGunStand", gameObject);
    }

    [SerializeField]protected TowerCtrl towerPrefab;
    private void Update()
    {
        ShowTowerToPlace();
    }

    protected virtual void ShowTowerToPlace()
    {
        newTowerId = TowerSelection();
        
        if(newTowerId == TowerCodeName.NoName) return;
        if (towerPrefab == null)
        {
            towerPrefab = GetTowerPrefabs(newTowerId);
            Vector3 prefabPos = gunStand.Point.transform.position;
            towerPrefab.transform.position = prefabPos;
            towerPrefab.SetActive(true);
        }
    }

    protected TowerCtrl GetTowerPrefabs(TowerCodeName TowerId)
    {
        return TowerSingleton.Instance.Prefabs.PoolPrefabs.GetByName(TowerId.ToString());
    }
    protected virtual TowerCodeName TowerSelection()
    {
        KeyCode pressKey =  InputHotKeys.Instance?.KeyCode ?? KeyCode.None;
        if (pressKey == KeyCode.None)
        {
            return TowerCodeName.NoName;
            
        }
        int keyIndex = (int)(pressKey - KeyCode.Alpha0);
        
        if(keyIndex >= 0 && keyIndex <= 9 &&Enum.IsDefined(typeof(TowerCodeName), keyIndex))
        {
            TowerCodeName newTower = (TowerCodeName)keyIndex;
            return newTower;
        }
        
        return newTowerId = TowerCodeName.NoName;
    }
}
