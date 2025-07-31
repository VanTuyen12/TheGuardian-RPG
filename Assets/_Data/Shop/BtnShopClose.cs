using UnityEngine;

public class BtnShopClose : ButtonAbstract
{
    public override void OnClick()
    {
        this.CloseShopUI();
    }

    protected virtual void CloseShopUI()
    {
        ShopUIManager.Instance.Hide();
    }
}
