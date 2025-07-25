using System;
using UnityEngine;

public class TowerUpgardeUI : ToggleAbstractUI<TowerUpgardeUI>
{
    [SerializeField]protected bool canOpenTowerUI = false;
    [SerializeField]protected GameObject handleTower;
    public GameObject HandleTower => handleTower;
   
    private void HandleTowerCollistion(bool obj, GameObject pointTower)
    {
       canOpenTowerUI = obj;
       handleTower =  pointTower;
    }

    protected override void HotkeyToogleInventory()
    {
      if( canOpenTowerUI && InputHotKeys.Instance.IsTooleTowerUI) Toggle();
      if (!canOpenTowerUI) Hide();
      
    }
    
    protected virtual void OnEnable()
    {
        GameEvent.OnTowerCollider += HandleTowerCollistion;
    }
    protected virtual void OnDisable()
    {
        GameEvent.OnTowerCollider -= HandleTowerCollistion;
    }
}
