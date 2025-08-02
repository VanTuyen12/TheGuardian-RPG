using UnityEngine;

public class SettingsUIManager : ToggleAbstractUI<SettingsUIManager>
{
    protected override void HotkeyToogleInventory()
    {
        if(InputHotKeys.Instance.IsSettings) Toggle();
    }
}
