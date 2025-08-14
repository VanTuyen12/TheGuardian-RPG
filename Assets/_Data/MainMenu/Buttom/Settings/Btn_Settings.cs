using UnityEngine;

public class Btn_Settings : ButtonAbstract
{
    public override void OnClick()
    { 
        var gameMenu = GameMenuManager.Instance;
        gameMenu.PlaySetings();
        gameMenu.Animator.SetBool("ShowSettings",true);
    }
}
