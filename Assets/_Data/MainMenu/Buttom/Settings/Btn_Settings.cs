using UnityEngine;

public class Btn_Settings : ButtonAbstract
{
    public override void OnClick()
    { 
        var gameMenu = GameMenuManager.Instance;
        bool isShow = gameMenu.SettingCtrl.IsShow;
        
        gameMenu.Animator.SetBool("ShowSettings",isShow);
    }
}
