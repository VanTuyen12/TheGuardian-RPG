using UnityEngine;

public class BtnInventoryToggle : ButtonAbstract
{
    public override void OnClick()
    {
       InventoryUI.Instance.Toggle();
    }

    public override string GetName()
    {
        return "BtnInventoryToggle";
    }
}
