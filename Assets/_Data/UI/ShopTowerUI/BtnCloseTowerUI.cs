using UnityEngine;

public class BtnCloseTowerUI : ButtonAbstract
{
    public override void OnClick()
    {
        this.CloseTowerUI();
    }

    protected virtual void CloseTowerUI()
    {
        TowerUIManager.Instance.Hide();
    }
}
