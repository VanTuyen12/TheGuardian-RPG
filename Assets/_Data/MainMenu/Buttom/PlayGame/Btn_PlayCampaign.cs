using UnityEngine;

public class Btn_PlayCampaign : ButtonAbstract
{
    public override void OnClick()
    {
        PlayGameCtrl.Instance.Toggle();
        GameMenuManager.Instance.ExitCtrl.Hide();
    }
}
