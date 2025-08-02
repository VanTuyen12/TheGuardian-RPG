using System;
using UnityEngine;

public class BtnShopToggle : ButtonAbstract
{
    public override void OnClick()
    {
       ShopUIManager.Instance.Toggle();
    }
    
}
