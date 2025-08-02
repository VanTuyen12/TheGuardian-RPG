using System.Collections.Generic;
using UnityEngine;

public class ShopUIManager : ToggleAbstractUI<ShopUIManager>
{
    [Header("Shop Logic")]
    [SerializeField] protected List<ShopItemData> shopItems = new();
    public List<ShopItemData> ShopItems => shopItems;
    
    [Header("Shop UI")]
    [SerializeField]protected SlotItemShop slotItemShop;
    public SlotItemShop SlotItemShop => slotItemShop;
    protected List<SlotItemShop> shopSlots = new();
    
    public override void Show()
    {
        base.Show();
        RefreshShop();
    }
    protected override void HotkeyToogleInventory()
    {
        if(InputHotKeys.Instance.IsToogleShopUI) Toggle();
    }

    protected override void Start()
    {
        base.Start();
        this.HideDefaultItemShop();
        this.InitializeShop();
    }
    
    protected virtual void InitializeShop()
    {
        this.LoadDefaultShopItems();
        this.CreateShopSlots();
    }
    
    protected virtual void LoadDefaultShopItems()
    {
        if (shopItems.Count > 0) return;
        
        shopItems.Add(new ShopItemData(ItemCode.Bullet1, 100, 30));
        shopItems.Add(new ShopItemData(ItemCode.Bullet2, 150, 10));
        shopItems.Add(new ShopItemData(ItemCode.GunMac, 500, 1));
        shopItems.Add(new ShopItemData(ItemCode.PotionMana, 250, 10));
    }
    
    protected virtual void CreateShopSlots()
    {
        Transform shopItemPos = slotItemShop.transform.parent;
        
        if (shopItemPos == null || slotItemShop == null) return;
        
        foreach (ShopItemData shopItem in shopItems)
        {
            SlotItemShop newSlot = Instantiate(slotItemShop, shopItemPos,false);
            newSlot.SetItem(shopItem.itemCode, shopItem.price, shopItem.quantity);
            newSlot.SetActive(true);
            shopSlots.Add(newSlot);
        }
    }
    
    public virtual void RefreshShop()
    {
        foreach (SlotItemShop slot in shopSlots)
        {
            slot.UpdateDisplay();
        }
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
    protected virtual void HideDefaultItemShop()
    {
        this.slotItemShop.gameObject.SetActive(false);
    }
}
