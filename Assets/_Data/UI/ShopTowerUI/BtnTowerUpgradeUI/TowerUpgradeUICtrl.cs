using UnityEngine;

public class TowerUpgradeUICtrl : MyMonoBehaviour
{
    [Header("Tower Type")]
    [SerializeField] protected TowerCodeName towerType;
    
    [Header("Upgrade Buttons")]
    [SerializeField] protected BtnUpgradeDamage damageButton;
    [SerializeField] protected BtnUpgradeSpeed speedButton;
    
    protected override void Start()
    {
        base.Start();
        SetupButtons();
    }
    
    protected virtual void SetupButtons()
    {
        if (damageButton != null)
        {
            damageButton.SetTargetTowerType(towerType);
        }
        
        if (speedButton != null)
        {
            speedButton.SetTargetTowerType(towerType);
        }
    }
    
    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadUpgradeButtons();
    }
    
    protected virtual void LoadUpgradeButtons()
    {
        if (damageButton != null) return;
            damageButton = transform.GetComponentInChildren<BtnUpgradeDamage>();
            
        if (speedButton != null) return;
            speedButton = transform.GetComponentInChildren<BtnUpgradeSpeed>();
        
        Debug.Log($"{transform.name}: LoadUpgradeButtons", gameObject);
    }
}
