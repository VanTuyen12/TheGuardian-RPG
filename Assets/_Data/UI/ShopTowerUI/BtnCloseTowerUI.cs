using UnityEngine;

public class BtnCloseTowerUI : ButtonAbstract
{
    public override void OnClick()
    {
        this.CloseTowerUI();
    }

    protected virtual void CloseTowerUI()
    {
        TowerUpgardeUI.Instance.Hide();
    }
}
