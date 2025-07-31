using System;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : ToggleAbstractUI<InventoryUI>
{
    [SerializeField]protected BtnItemInventory btnItemInventory;
    [SerializeField]protected List<BtnItemInventory> btnItems = new();

    private void FixedUpdate()
    {
        ItemsUpdating();
    }
    protected virtual void ItemsUpdating()
    {
        if (!this.isShow) return;

        InventoryCtrl itemInvCtrl = InventoryManager.Instance.Items();

        foreach (ItemInventory itemInventory in itemInvCtrl.Items)
        {
            BtnItemInventory newBtnItem = this.GetExistItem(itemInventory);
            if (newBtnItem == null)
            {
                newBtnItem = Instantiate(this.btnItemInventory);
                newBtnItem.transform.SetParent(this.btnItemInventory.transform.parent, false);
                newBtnItem.SetItem(itemInventory);
                newBtnItem.gameObject.SetActive(true);
                newBtnItem.name = itemInventory.GetItemName() + "-" + itemInventory.ItemId;
                this.btnItems.Add(newBtnItem);
            }
        }
    }
    protected override void HotkeyToogleInventory()
    {
        if(InputHotKeys.Instance.IsToogleInvUI) Toggle();
    }
    
    protected virtual BtnItemInventory GetExistItem(ItemInventory itemInventory)
    {
        foreach (BtnItemInventory itemInvUI in this.btnItems)
        {
            if (itemInvUI.ItemInventory.ItemId == itemInventory.ItemId) return itemInvUI;
        }
        return null;
    }
    
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadBtnItemInventory();
    }

    protected override void Start()
    {
        base.Start();
        this.HideDefaultItemInventory();
    }

    protected virtual void LoadBtnItemInventory()
    {
        if (this.btnItemInventory != null) return;
        this.btnItemInventory = GetComponentInChildren<BtnItemInventory>();
        Debug.Log(transform.name + ": LoadBtnItemInventory", gameObject);
    }
    protected virtual void HideDefaultItemInventory()
    {
        this.btnItemInventory.gameObject.SetActive(false);
    }
}
