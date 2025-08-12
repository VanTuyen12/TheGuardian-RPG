using UnityEngine;

public class SettingsUIManager : GameplayToggleUI<SettingsUIManager>
{
    protected override void HotkeyToogleUI()
    {
        if(InputHotKeys.Instance.IsSettings) Toggle();
    }
}
