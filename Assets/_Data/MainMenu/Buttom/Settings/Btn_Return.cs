using UnityEngine;

public class Btn_Return : ButtonAbstract
{
    public override void OnClick()
    {
        var isShow = SettingCtrl.Instance.IsShow;
        GameMenuManager.Instance.Animator.SetBool("ShowSettings",!isShow);
    }
}
