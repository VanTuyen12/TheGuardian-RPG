using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public abstract class BtnAbsTowerUpgardeUI : ButtonAbstract
{
    [SerializeField]protected TowerUpgardeUI upgardeCtrlUI;
    [SerializeField]protected TowerStandCtrl towerStand;
    public TowerStandCtrl TowerStand => towerStand;
    
    protected virtual void OnEnable()
    {
        if (upgardeCtrlUI == null || !upgardeCtrlUI.IsShow) return;
        
        towerStand = upgardeCtrlUI.StandCtrl;
        if (towerStand == null) return;
        
        TowerPurchased( TowerName());
    }
    protected virtual void OnDisable()
    {
        towerStand = null;
    }

    protected abstract TowerCodeName TowerName(); 
    protected virtual void ComeBuyTower(TowerCodeName towerType)
    {
        if (towerStand.CanBuyTower(towerType))
        {
            towerStand.BuyTower(towerType);
            HideBuyButton();
            Debug.Log(towerType + "Tower được mua" );
        }
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
        if (this.upgardeCtrlUI != null) return;
        upgardeCtrlUI = FindAnyObjectByType<TowerUpgardeUI>();
        Debug.Log(transform.name + " :LoadTowerUpgardeUI", gameObject);
    }
}
