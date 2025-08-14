using UnityEngine;

public class Btn_Return : ButtonAbstract
{
    public override void OnClick()
    {
        GameMenuManager.Instance.Animator.SetBool("ShowSettings",false);
    }
}
