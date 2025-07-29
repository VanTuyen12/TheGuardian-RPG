using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class TowerStandUICtrl : MyMonoBehaviour
{
    [Header("Tower Type")]
    [SerializeField] protected TowerCodeName towerType;
    
    [Header("Upgrade Text")]
    [SerializeField] protected TextTowerStandUI txtTowerStandUI;
    
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
        if (txtTowerStandUI != null)
        {
            txtTowerStandUI.SetTargetTowerType(towerType);
        }
    }
    
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadUpgradeButtons();
        this.LoadTowerStandUI();
    }
    
    protected virtual void LoadUpgradeButtons()
    {
        if (damageButton != null) return;
            damageButton = transform.GetComponentInChildren<BtnUpgradeDamage>();
            
        if (speedButton != null) return;
            speedButton = transform.GetComponentInChildren<BtnUpgradeSpeed>();
        
        Debug.Log($"{transform.name}: LoadUpgradeButtons", gameObject);
    }

    protected virtual void LoadTowerStandUI()
    {
        if ( txtTowerStandUI!= null) return;
        txtTowerStandUI = transform.GetComponentInChildren<TextTowerStandUI>();
        Debug.Log($"{transform.name}: LoadTowerStandUI", gameObject);
    }
}
