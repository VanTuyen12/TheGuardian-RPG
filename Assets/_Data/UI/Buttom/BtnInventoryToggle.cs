using System;
using UnityEngine;

public class BtnInventoryToggle : ButtonAbstract
{
    public override void OnClick()
    {
       InventoryUI.Instance.Toggle();
    }
    
}
