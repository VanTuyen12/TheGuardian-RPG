using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public abstract class SlotItemShop : MyMonoBehaviour
{
    [SerializeField]protected TextMeshProUGUI txtItemName;
    [SerializeField]protected Button btnBuyItem;
    [SerializeField]protected Image imageItemShop;
    
    [SerializeField]protected ItemInventory itemInventory;
    public ItemInventory ItemInventory => itemInventory;
    
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
        btnBuyItem = transform.Find("BtnBuyItem").GetComponent<Button>();
        
        if (imageItemShop != null) return;
        imageItemShop = transform.Find("ImageItemShop/ImageItem").GetComponent<Image>();
        
        Debug.Log(transform.name+ " :LoadtxtBtnItem",gameObject);
    }
}
