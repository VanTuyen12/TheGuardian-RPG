using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class TowerManager : Singleton<TowerManager>
{
    [SerializeField]protected TowerCodeName newTowerId = TowerCodeName.NoName;
    public TowerCodeName NewTowerId => newTowerId;
    [SerializeField]protected List<TowerProfiles> towerProfiles = new List<TowerProfiles>();
    public List<TowerProfiles> TowerProfiles => towerProfiles;

    public virtual TowerProfiles GetProfileByCode(TowerCodeName towerCodeName)
    {
        foreach (TowerProfiles itemProfile in towerProfiles)
        {
            if(itemProfile.towerType == towerCodeName) return itemProfile;
        }
        return null;
    }
    public int GetPrice(TowerCodeName towerType)
    {
        foreach (var price in towerProfiles)
        {
            if (price.towerType == towerType)
                return price.price;
        }
        return 0;
    }
    
    public string GetDisplayName(TowerCodeName towerType)
    {
        foreach (var price in towerProfiles)
        {
            if (price.towerType == towerType)
                return price.currencyName;
        }
        return towerType.ToString();
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadTowerProfiles();
    }

    protected virtual void LoadTowerProfiles()
    {
        if (TowerProfiles.Count > 0) return;
        TowerProfiles[] tower = Resources.LoadAll<TowerProfiles>("TowerProfiles");
        TowerProfiles.AddRange(tower);
        
        Debug.Log(transform.name +" LoadTowerProfiles: ",gameObject);
    }
    
}
