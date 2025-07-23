using System;
using System;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : ToggleAbstractUI<InventoryUI>
{
    protected override void HotkeyToogleInventory()
    {
        if(InputHotKeys.Instance.IsToogleInvUI) Toggle();
    }
}
