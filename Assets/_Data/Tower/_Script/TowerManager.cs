using System;
using UnityEngine;
using UnityEngine.Serialization;

public class TowerManager : Singleton<TowerManager>
{
    [SerializeField]protected TowerCodeName newTowerId = TowerCodeName.NoName;
    public TowerCodeName NewTowerId => newTowerId;
   

    
    private void Update()
    {
        //UpdateBuyTower();
    }
    /*protected virtual void UpdateBuyTower()
    {
        
        if (towerPrefab == null)
        {
            towerPrefab = GetTowerPrefabs(newTowerId);
            Vector3 prefabPos = gunStand.Point.transform.position;
            towerPrefab.transform.position = prefabPos;
            towerPrefab.SetActive(true);
        }
    }
    protected virtual void ShowTowerToPlace(Vector3 point)
    {
        
        if (towerPrefab == null)
        {
            towerPrefab = GetTowerPrefabs(newTowerId);
            Vector3 prefabPos = gunStand.Point.transform.position;
            towerPrefab.transform.position = prefabPos;
            towerPrefab.SetActive(true);
        }
    }*/

    public virtual bool SelectHotKey()
    {
        newTowerId = TowerSelection();
        if(newTowerId == TowerCodeName.NoName) return false;
        return true;
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
