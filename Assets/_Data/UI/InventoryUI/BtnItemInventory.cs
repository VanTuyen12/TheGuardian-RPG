using System;
using TMPro;
using UnityEngine;

public class BtnItemInventory : ButtonAbstract
{
    [SerializeField]protected TextMeshProUGUI txtItemName;
    [SerializeField]protected TextMeshProUGUI txtItemCount;
    protected ItemInventory itemInventory;
    public ItemInventory ItemInventory => itemInventory;

    private void FixedUpdate()
    {
        ItemUpdating();
    }

    protected virtual void ItemUpdating()
    {
        
        this.txtItemName.text = itemInventory.itemName;
        this.txtItemCount.text = itemInventory.itemCount.ToString();

        if (itemInventory.itemCount <= 0)
        {
            despawn.DoDespawn();
        }
        
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
        this.LoadtxtBtnItem();
    }

    public override string GetName()
    {
        return "ItemInventory";
    }

    protected virtual void LoadtxtBtnItem()
    {
        if (txtItemName != null) return;
        txtItemName = transform.Find("txtItemName").GetComponent<TextMeshProUGUI>();
        txtItemCount = transform.Find("txtItemCount").GetComponent<TextMeshProUGUI>();
        Debug.Log(transform.name+ " :LoadtxtBtnItem",gameObject);
    }
}
