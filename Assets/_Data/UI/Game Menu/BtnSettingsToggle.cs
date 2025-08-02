using UnityEngine;

public class BtnSettingsToggle : ButtonAbstract
{
    public override void OnClick()
    {
        SettingsUIManager.Instance.Toggle();
    }
}
