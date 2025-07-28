using System;
using UnityEngine;

public class TowerUpgardeUI : ToggleAbstractUI<TowerUpgardeUI>
{
    [SerializeField]protected bool canOpenTowerUI = false;
    public bool CheckOpenTowerUI => canOpenTowerUI;
    [SerializeField]protected GameObject handleTower;
    public GameObject HandleTower => handleTower;
    [SerializeField] protected BtnAbsTowerUpgardeUI btnTowerUpgardeUI;
    public BtnAbsTowerUpgardeUI BtnTowerUpgardeUI => btnTowerUpgardeUI;
   
    private void HandleTowerCollistion(bool obj, GameObject pointTower)
    {
       canOpenTowerUI = obj;
       handleTower =  pointTower;
    }

    protected override void HotkeyToogleInventory()
    {
      if( canOpenTowerUI && InputHotKeys.Instance.IsTooleTowerUI) Toggle();
      if (!canOpenTowerUI)
      {
          handleTower =  null;
          Hide();
      } 
    }
    
    protected virtual void OnEnable()
    {
        GameEvent.OnTowerCollider += HandleTowerCollistion;
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
        if (btnTowerUpgardeUI!= null) return;
        btnTowerUpgardeUI = GetComponentInChildren<BtnAbsTowerUpgardeUI>();
        Debug.Log(transform.name + " :BtnAbsTowerUpgardeUI ",gameObject);
    }
}
