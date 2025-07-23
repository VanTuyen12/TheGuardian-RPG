using UnityEngine;

public class TowerUpgardeUI : ToggleAbstractUI<TowerUpgardeUI>
{

    protected override void HotkeyToogleInventory()
    {
      if( InputHotKeys.Instance.IsTooleTowerUI) Toggle();
    }
    
}
