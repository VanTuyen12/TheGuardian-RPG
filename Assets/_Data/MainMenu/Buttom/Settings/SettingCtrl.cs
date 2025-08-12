using UnityEngine;

public class SettingCtrl : ToggleAbstractUI<SettingCtrl>
{
    protected override void Start()
    {
        base.Start();
        Show();
    }

    protected override void HotkeyToogleUI()
    {
        //No Comment
    }
    
}
