using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class ShopManager : Singleton<ShopManager>
{
    [SerializeField] protected List<ShopItemData> shopItems = new();
    public List<ShopItemData> ShopItems => shopItems;
    
    [SerializeField] protected Transform shopItemPos;
    [SerializeField] protected SlotItemShop shopItemPrefab;
    
    protected List<SlotItemShop> shopSlots = new();
    
    
    protected override void Start()
    {
        base.Start();
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
        shopItemPrefab = ShopUICtrl.Instance.SlotItemShop;
        shopItemPos = shopItemPrefab.transform.parent;
        
        if (shopItemPos == null || shopItemPrefab == null) return;
        
        foreach (ShopItemData shopItem in shopItems)
        {
            SlotItemShop newSlot = Instantiate(shopItemPrefab, shopItemPos,false);
            newSlot.SetItem(shopItem.itemCode, shopItem.price, shopItem.quantity);
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
}
