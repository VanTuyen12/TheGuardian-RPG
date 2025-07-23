using System;
using UnityEngine;
using Random = System.Random;

[Serializable]
public class ItemInventory
{
    protected int itemId ;
    public int ItemId => itemId;
    public string itemName;
    public int itemCount;
    
    public ItemProfileSO itemProfile;
    public ItemProfileSO ItemProfile => itemProfile;
    public virtual void SetId(int id)
    {
        this.itemId = id;
    }
    public virtual void SetName(string name)
    {
        this.itemName = name;
    }
    public ItemInventory(ItemProfileSO itemProfile, int itemCount)
    {
        this.itemProfile = itemProfile;
        this.itemCount = itemCount;
        this.itemName = this.itemProfile.itemName;
    }
    public virtual string GetItemName()
    {
        if (this.itemName == null || this.itemName == "") return this.itemProfile.itemName;
        return this.itemName;
    }
    
    public virtual bool Deduct(int number)
    {
        if (!this.CanDeduct(number)) return false;
        this.itemCount -= number;
        return true;
    }
    
    public virtual bool CanDeduct(int number)
    {
        return this.itemCount >= number;
    }
}
