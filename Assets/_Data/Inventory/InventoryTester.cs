using com.cyborgAssets.inspectorButtonPro;
using UnityEngine;

public class InventoryTester : MyMonoBehaviour
{
    protected override void Start()
    {
        base.Start();
        this.AddTestItems(ItemCode.Gold, 10000);
        this.AddTestItems(ItemCode.Bullet1, 120);
        this.AddTestItems(ItemCode.Bullet2, 60);
    }

    [ProButton]
    public virtual void AddTestItems(ItemCode itemCode, int count)
    {
        for (int i = 0; i < count; i++)
        {
            InventoryManager.Instance.AddItem(itemCode, 1);
        }
    }

    [ProButton]
    public virtual void RemoveTestItems(ItemCode itemCode, int count)
    {
        for (int i = 0; i < count; i++)
        {
            InventoryManager.Instance.RemoveItem(itemCode, 1);
        }
    }
}
