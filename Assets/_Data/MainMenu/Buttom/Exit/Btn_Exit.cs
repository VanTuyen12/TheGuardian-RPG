using UnityEngine;

public class Btn_Exit : ButtonAbstract
{
    public override void OnClick()
    {
        ExitCtrl.Instance.Toggle();
        GameMenuManager.Instance.PlayGameCtrl.Hide();
    }
}
