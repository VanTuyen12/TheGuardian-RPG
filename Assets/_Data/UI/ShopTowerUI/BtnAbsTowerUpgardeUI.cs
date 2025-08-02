using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public abstract class BtnAbsTowerUpgardeUI : ButtonAbstract
{
    [SerializeField]protected TowerUIManager ctrlUIManager;
    private TowerStandCtrl towerStand;
    [SerializeField]protected TowerProfiles towerProfiles;
    [SerializeField]protected ItemCode currency = ItemCode.Gold;
    
    protected virtual void OnEnable()
    {
        if (ctrlUIManager == null || !ctrlUIManager.IsShow) return;
        
        towerStand = ctrlUIManager.StandCtrl;
        if (towerStand == null) return;
        
        TowerPurchased( TowerName());
    }
    protected virtual void OnDisable()
    {
        towerStand = null;
    }

    
    protected virtual bool UpdatePriceDisplay()
    {
       if (towerStand == null) return false;
       TowerCodeName towerType = TowerName();
       if (towerStand.IsTowerBought(towerType)) return false;
       int cost = GetTowerCost(towerType);
       bool canAfford = HasEnoughGold(cost);
       
       return canAfford;
    }

    protected virtual int GetTowerCost(TowerCodeName towerType)
    {
        return TowerManager.Instance.GetPrice(towerType);
        /*towerProfiles = TowerManager.Instance.GetProfileByCode(towerType);
        return towerProfiles != null ? towerProfiles.price : 0;*/
    }
    protected virtual bool HasEnoughGold(int cost)
    {
        int currentGold = GetCurrentGold();
        return currentGold >= cost;
    }
    
    protected virtual int GetCurrentGold()
    {
        var goldItem = InventoryManager.Instance.Currency().FindItem(currency);
        return goldItem?.itemCount ?? 0;
    }
    
    protected virtual void SpendGold(int amount)
    {
        InventoryManager.Instance.RemoveItem(currency, amount);
    }
    
    protected abstract TowerCodeName TowerName(); 
    protected virtual void ComeBuyTower(TowerCodeName towerType)
    {
        if (!towerStand.CanBuyTower(towerType)) return;
        if(!UpdatePriceDisplay()) return;
        
        towerStand.BuyTower(towerType);
        SpendGold(GetTowerCost(TowerName()));
        HideBuyButton();
    }
    
    protected virtual void TowerPurchased(TowerCodeName towerType)
    {
        if (!towerStand.IsTowerBought(towerType))
        {
            ShowBuyButton();
        }
    }
    
    protected virtual void HideBuyButton()
    {
        button.interactable = false;
    }
    
    protected virtual void ShowBuyButton()
    {
        button.interactable = true;
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadTowerUpgardeUI();
    }
    
    protected virtual void LoadTowerUpgardeUI()
    {
        if (this.ctrlUIManager != null) return;
        ctrlUIManager = FindAnyObjectByType<TowerUIManager>();
        Debug.Log(transform.name + " :LoadTowerUpgardeUI", gameObject);
    }
}
