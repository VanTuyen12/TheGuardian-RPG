using System;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : Singleton<InventoryUI>
{
    [SerializeField]protected BtnItemInventory defaultItemInventoryUI;
    protected List<BtnItemInventory> btnItems = new();
    [SerializeField]private bool isShow = false;
    public bool IsShow => isShow;

    protected override void Start()
    {
        base.Start();
        //Hide();
        Show();
        this.HideDefaultItemInventory();
    }

    private void FixedUpdate()
    {
        ItemUpdating();
    }

    protected virtual void HideDefaultItemInventory()
    {
        defaultItemInventoryUI.gameObject.SetActive(false);
    }

    public virtual void Show()
    {
        isShow = true;
        gameObject.SetActive(isShow);
    }

    public virtual void Hide()
    {
        isShow = false;
        gameObject.SetActive(isShow);
    }

    public virtual void Toggle()
    {
        if (isShow) Hide();
        else Show();
        
    }
    
    protected virtual void ItemUpdating()
    {
        InventoryCtrl itemInvCtrl = InventoryManager.Instance.Items();
        foreach (ItemInventory itemInventory in itemInvCtrl.Items)
        {
            BtnItemInventory newBtnItem = GetExistItem(itemInventory);
            if (newBtnItem == null)
            {
                newBtnItem = Instantiate(defaultItemInventoryUI);
                newBtnItem.transform.SetParent(defaultItemInventoryUI.transform.parent);
                newBtnItem.SetItem(itemInventory);
                newBtnItem.transform.localScale = Vector3.one;
                newBtnItem.gameObject.SetActive(true);
                btnItems.Add(newBtnItem);
            }
        }
    }

    protected virtual BtnItemInventory GetExistItem(ItemInventory itemInventory)
    {
        foreach (BtnItemInventory itemInvUI in btnItems)
        {
            if (itemInvUI.ItemInventory.itemId == itemInventory.itemId) return itemInvUI;
        }
        
        return null;
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadBtnItemInventory();
    }

    protected virtual void LoadBtnItemInventory()
    {
        if (defaultItemInventoryUI != null) return;
        defaultItemInventoryUI = GetComponentInChildren<BtnItemInventory>();
        Debug.Log(transform.name + ": LoadBtnItemInventory", gameObject);
    }
}
