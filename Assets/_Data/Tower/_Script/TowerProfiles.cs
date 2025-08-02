using UnityEngine;

[CreateAssetMenu(fileName = "TowerProfiles", menuName = "ScriptableObjects/TowerProfiles")]
public class TowerProfiles : ScriptableObject
{
    public TowerCodeName towerType;
    public int price;
    public string currencyName;
}
