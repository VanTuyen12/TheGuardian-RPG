using System;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : Singleton<InventoryUI>
{
    [SerializeField]protected BtnItemInventory defaultItemInventoryUI;
    [SerializeField]protected List<BtnItemInventory> btnItems = new();
    [SerializeField] protected InventorySpawner invSpawner;
    public InventorySpawner InvSpawner => invSpawner;
    [SerializeField]protected bool isShow = false;
        
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
              
                newBtnItem = invSpawner.Spawn(defaultItemInventoryUI);
                DefaultBtnItem(newBtnItem);
                newBtnItem.SetItem(itemInventory);
                newBtnItem.gameObject.SetActive(true);
                newBtnItem.name = itemInventory.itemName;
                btnItems.Add(newBtnItem);
            }
        }
    }

    protected virtual void DefaultBtnItem(BtnItemInventory newBtnItem)
    {
        newBtnItem.transform.SetParent(defaultItemInventoryUI.transform.parent, false);
        newBtnItem.transform.localScale = Vector3.one;
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
        this.LoadInventorySpawner();
    }
    protected virtual void LoadInventorySpawner()
    {
        if (invSpawner != null) return;
        invSpawner = FindAnyObjectByType<InventorySpawner>();
        Debug.Log(transform.name + ": LoadInventorySpawner", gameObject);
    }
    protected virtual void LoadBtnItemInventory()
    {
        if (defaultItemInventoryUI != null) return;
        defaultItemInventoryUI = GetComponentInChildren<BtnItemInventory>();
        Debug.Log(transform.name + ": LoadBtnItemInventory", gameObject);
    }
}
