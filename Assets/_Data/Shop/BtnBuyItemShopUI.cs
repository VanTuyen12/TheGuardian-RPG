using TMPro;
using UnityEngine;

public class BtnBuyItemShopUI : ButtonAbstract
{
   [SerializeField] protected ItemCode itemCode;
   public ItemCode ItemCode => itemCode;
   
   [SerializeField] protected int itemPrice;
   public int ItemPrice => itemPrice;
   
   [SerializeField] protected int itemQuantity = 1;
   public int ItemQuantity => itemQuantity;
    
   [SerializeField] protected TextMeshProUGUI txtPrice;
    
   [SerializeField]protected SlotItemShop parentSlot;
   public override void OnClick()
   {
      this.TryBuyItem();
   }
   protected virtual void TryBuyItem()
   {
      if (!this.CheckMoney())return;
      this.BuyItem();
   }
   protected virtual bool CheckMoney()
   {
      InventoryCtrl currencyInventory = InventoryManager.Instance.Currency();
      ItemInventory goldItem = currencyInventory.FindItem(ItemCode.Gold);
        
      if (goldItem == null) return false;
      return goldItem.itemCount >= itemPrice;
   }
    
   protected virtual void BuyItem()
   {
      InventoryManager.Instance.RemoveItem(ItemCode.Gold, itemPrice);
      InventoryManager.Instance.AddItem(itemCode, itemQuantity);
      
      this.UpdateUI();
   }
   
    
   protected virtual void UpdateUI()
   {
      // Cập nhật hiển thị tiền
      if (parentSlot != null)
      {
         parentSlot.UpdateDisplay();
      }
   }
    
   public virtual void SetupItem(ItemCode code, int price, int quantity = 1)
   {
      this.itemCode = code;
      this.itemPrice = price;
      this.itemQuantity = quantity;
        
      if (txtPrice != null)
      {
         txtPrice.text = price.ToString();
      }
   }
   protected override void LoadComponents()
   {
      base.LoadComponents();
      this.LoadParentSlot();
      this.LoadPriceText();
   }
    
   protected virtual void LoadParentSlot()
   {
      if (parentSlot != null) return;
      parentSlot = GetComponentInParent<SlotItemShop>();
      Debug.Log(transform.name + ": LoadParentSlot", gameObject);
   }
    
   protected virtual void LoadPriceText()
   {
      if (txtPrice != null) return;
      txtPrice = GetComponentInChildren<TextMeshProUGUI>();
      Debug.Log(transform.name + ": LoadPriceText", gameObject);
   }
}
