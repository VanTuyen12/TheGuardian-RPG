using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BtnItemInventory : ButtonAbstract
{
    [SerializeField]protected TextMeshProUGUI txtItemName;
    [SerializeField]protected TextMeshProUGUI txtItemCount;
    [SerializeField]protected Image imageItem;
    
    [SerializeField]protected ItemInventory itemInventory;
    public ItemInventory ItemInventory => itemInventory;

    private void FixedUpdate()
    {
        ItemUpdating();
    }

    protected virtual void ItemUpdating()
    {
        if (itemInventory == null) return;
        
        this.txtItemName.text = itemInventory.itemName;
        this.txtItemCount.text = itemInventory.itemCount.ToString();
        this.imageItem.sprite = itemInventory.itemImage;

        if (this.itemInventory.itemCount == 0) Destroy(gameObject);
        
    }

    public virtual void SetItem(ItemInventory itemInv)
    {
        this.itemInventory = itemInv;
    }
    public override void OnClick()
    {
        Debug.Log("OnClick Item");
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSetupBtnItem();
    }
    

    protected virtual void LoadSetupBtnItem()
    {
        if (txtItemName != null) return;
        txtItemName = transform.Find("TextItemName").GetComponent<TextMeshProUGUI>();
        
        if (txtItemCount != null) return;
        txtItemCount = transform.Find("TextItemCount").GetComponent<TextMeshProUGUI>();
        
        if (imageItem != null) return;
        imageItem = transform.Find("ImageItem").GetComponent<Image>();
        
        Debug.Log(transform.name+ " :LoadtxtBtnItem",gameObject);
    }
   
}
