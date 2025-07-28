using UnityEngine;
public class TowerState 
{ 
    public TowerCodeName TowerType { get; private set; }
    public bool IsBought { get; set; }
    public TowerState(TowerCodeName towerType)
    {
        TowerType = towerType;
        IsBought = false;
    }
}
