using System;
using UnityEngine;

public class InputHotKeys : Singleton<InputHotKeys>
{
    protected bool isToogleInvUI = false;
    public bool IsToogleInvUI => isToogleInvUI;
    [SerializeField] protected KeyCode keyCode;
    public KeyCode KeyCode => keyCode;

    protected virtual void Update()
    {
        this.OpenInventory();
        this.ToogleNumber();
    }

    protected virtual void ToogleNumber()
    {
        for (int i = 0; i <= 9; i++)
        {
            KeyCode key = KeyCode.Alpha0 + i; 
            if (Input.GetKeyDown(key))
            {
                keyCode = (keyCode == key) ? KeyCode.None : key;
                break;
            }
        }
    }

    public virtual void OpenInventory()
    {
        isToogleInvUI = Input.GetKeyUp(KeyCode.I);
    }
    
}