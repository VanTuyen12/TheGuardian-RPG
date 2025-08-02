using UnityEngine;

public class BtnCloseSettings : ButtonAbstract
{
    public override void OnClick()
    {
        CloseSettings();
    }
    
    protected virtual void CloseSettings()
    {
        SettingsUIManager.Instance.Hide();
    }
}
