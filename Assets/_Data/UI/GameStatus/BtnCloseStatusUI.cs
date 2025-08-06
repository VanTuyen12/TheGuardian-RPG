using UnityEngine;

public class BtnCloseStatusUI : ButtonAbstract
{
    public override void OnClick()
    {
        this.CloseTowerUI();
    }

    protected virtual void CloseTowerUI()
    {
        GameStatusUI.Instance.Hide();
    }
}
