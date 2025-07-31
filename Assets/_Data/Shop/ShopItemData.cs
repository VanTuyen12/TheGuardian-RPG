using System;

[Serializable]
public class ShopItemData
{
    public ItemCode itemCode;
    public int price;
    public int quantity;
    
    public ShopItemData(ItemCode code, int itemPrice, int itemQuantity)
    {
        itemCode = code;
        price = itemPrice;
        quantity = itemQuantity;
    }
}