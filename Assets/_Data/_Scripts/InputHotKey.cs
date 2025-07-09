using System;
using UnityEngine;

public class InputHotKey : Singleton<InputHotKey>
{
    protected bool isToogleInvUI = false;
    public bool IsToogleInvUI => isToogleInvUI;

    protected virtual void Update()
    {
        this.OpenInventory();
    }

    public virtual void OpenInventory()
    {
        isToogleInvUI = Input.GetKeyUp(KeyCode.I);
    }
}