using UnityEngine;

public class Btn_No : ButtonAbstract
{
    public override void OnClick()
    {
        ExitCtrl.Instance.Hide();
    }
}
