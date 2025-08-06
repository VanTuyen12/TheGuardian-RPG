using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TowerUIManager : ToggleAbstractUI<TowerUIManager>
{
    [SerializeField]protected bool canOpenTowerUI = false;
    public bool CanOpenTowerUI => canOpenTowerUI;
    [SerializeField]protected GameObject handleTower;
    public GameObject HandleTower => handleTower;
    [SerializeField]protected TowerStandCtrl standCtrl;
    public TowerStandCtrl StandCtrl => standCtrl;
    [SerializeField] protected List<BtnAbsTowerUpgardeUI> btnTowerUpgardeUI;
    public List<BtnAbsTowerUpgardeUI> BtnTowerUpgardeUI => btnTowerUpgardeUI;
   
    private void HandleTowerCollistion(bool obj, GameObject pointTower)
    {
       canOpenTowerUI = obj;
       handleTower =  pointTower;
       LoadTowerStand();
    }

    protected override void HotkeyToogleInventory()
    {
      if( canOpenTowerUI && InputHotKeys.Instance.IsTooleTowerUI) Toggle();
      if (!canOpenTowerUI)
      {
          handleTower =  null;
          standCtrl = null;
          Hide();
      } 
    }
    
    protected virtual void OnEnable()
    {
        GameEvent.OnTowerCollider += HandleTowerCollistion;
    }

    protected virtual void LoadTowerStand()
    {
        standCtrl = handleTower == null  ? null : handleTower.GetComponent<TowerStandCtrl>();
    }
    protected virtual void OnDisable()
    {
        GameEvent.OnTowerCollider -= HandleTowerCollistion;
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.BtnAbsTowerUpgardeUI();
    }
    protected virtual void BtnAbsTowerUpgardeUI()
    {
        if (btnTowerUpgardeUI.Count > 0) return;
        btnTowerUpgardeUI = GetComponentsInChildren<BtnAbsTowerUpgardeUI>(true).ToList();
        Debug.Log(transform.name + " :BtnAbsTowerUpgardeUI ",gameObject);
    }
}
