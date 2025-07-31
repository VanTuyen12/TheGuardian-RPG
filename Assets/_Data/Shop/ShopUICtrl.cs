using UnityEngine;

public class ShopUICtrl : ToggleAbstractUI<ShopUICtrl>
{
    [SerializeField]protected SlotItemShop slotItemShop;
    public SlotItemShop SlotItemShop => slotItemShop;
    public override void Show()
    {
        base.Show();
        if (ShopManager.Instance != null)
        {
            ShopManager.Instance.RefreshShop();
        }
    }
    protected override void HotkeyToogleInventory()
    {
        if(InputHotKeys.Instance.IsToogleShopUI) Toggle();
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSlotItemShop();
    }
    protected virtual void LoadSlotItemShop()
    {
        if (this.slotItemShop != null) return;
        this.slotItemShop = GetComponentInChildren<SlotItemShop>();
        Debug.Log(transform.name + ": LoadSlotItemShop", gameObject);
    }
}
