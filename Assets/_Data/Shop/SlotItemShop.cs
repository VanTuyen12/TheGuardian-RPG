using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class SlotItemShop : MyMonoBehaviour
{
    [SerializeField]protected TextMeshProUGUI txtItemName;
    [SerializeField]protected BtnBuyItemShopUI btnBuyItem;
    [SerializeField]protected Image imageItemShop;
    
    [SerializeField]protected ItemInventory itemInventory;
    public ItemInventory ItemInventory => itemInventory;
    
    [SerializeField] protected ItemCode itemCode;
    public ItemCode ItemCode => itemCode;
    
    [SerializeField] protected int itemPrice;
    public int ItemPrice => itemPrice;
    
    [SerializeField] protected int itemQuantity = 1;
    public int ItemQuantity => itemQuantity;
    protected BtnBuyItemShopUI btnBuyItemShopUI;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSetupBtnItemShop();
    }
    

    protected virtual void LoadSetupBtnItemShop()
    {
        if (txtItemName != null) return;
        txtItemName = transform.Find("TextItemName").GetComponent<TextMeshProUGUI>();
        
        if (btnBuyItem != null) return;
        btnBuyItem = GetComponentInChildren<BtnBuyItemShopUI>();
        
        if (imageItemShop != null) return;
        imageItemShop = transform.Find("ImageItemShop/ImageItem").GetComponent<Image>();
        
        Debug.Log(transform.name+ " :LoadtxtBtnItem",gameObject);
    }
    protected override void Start()
    {
        base.Start();
        this.SetupShopItem();
    }
    
    protected virtual void SetupShopItem()
    {
        ItemProfileSO itemProfile = InventoryManager.Instance.GetProfileByCode(itemCode);
        if (itemProfile == null) return;
        
        // Setup UI
        if (txtItemName != null)
            txtItemName.text = itemProfile.itemName;
            
        if (imageItemShop != null)
            imageItemShop.sprite = itemProfile.image;
            
        // Setup button
        if (btnBuyItem != null)
            btnBuyItem.SetupItem(itemCode, itemPrice, itemQuantity);
    }
    
    public virtual void UpdateDisplay()
    {
        // Cập nhật hiển thị khi cần thiết
        this.SetupShopItem();
    }
    
    public virtual void SetItem(ItemCode code, int price, int quantity = 1)
    {
        this.itemCode = code;
        this.itemPrice = price;
        this.itemQuantity = quantity;
        this.SetupShopItem();
    }
}
