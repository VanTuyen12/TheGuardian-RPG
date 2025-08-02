using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class TowerUpgradeUICtrl : MyMonoBehaviour
{
    [Header("Tower Type")]
    [SerializeField] protected TowerCodeName towerType;
    
    [Header("Upgrade Text")]
    [SerializeField] protected TextTowerStandUI txtTowerStandUI;

    [SerializeField] protected TextTowerPriceUI txtTowerPrice;
    
    [Header("Upgrade Buttons")]
    [SerializeField] protected BtnUpgradeDamage damageButton;
    [SerializeField] protected BtnUpgradeSpeed speedButton;
    
    protected override void Start()
    {
        base.Start();
        SetupButtons();
        SetTextPriceTower();
    }

    protected virtual void SetTextPriceTower()
    {
        var towerObj = TowerManager.Instance.GetProfileByCode(towerType);
        int price = towerObj.price;
        string priceStr = towerObj.currencyName;
        if (txtTowerPrice != null)
        {
            txtTowerPrice.LoadPriceTower(price, priceStr);
        }
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
        this.LoadTowerPriceUI();
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
    
    protected virtual void LoadTowerPriceUI()
    {
        if ( txtTowerPrice!= null) return;
        txtTowerPrice = transform.GetComponentInChildren<TextTowerPriceUI>();
        Debug.Log($"{transform.name}: TextTowerPriceUI", gameObject);
    }
}
