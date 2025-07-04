using UnityEngine;

public class BtnCloseInventory : ButtonAbstract
{
    public override void OnClick()
    {
        this.CloseInventoryUI();
    }

    protected virtual void CloseInventoryUI()
    {
        InventoryUI.Instance.Hide();
    }
}
