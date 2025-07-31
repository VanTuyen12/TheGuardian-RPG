using UnityEngine;

public class ShopUIManager : ToggleAbstractUI<ShopUIManager>
{
    protected override void HotkeyToogleInventory()
    {
        if(InputHotKeys.Instance.IsToogleShopUI) Toggle();
    }
}
