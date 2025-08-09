using System;
using UnityEngine;

public class InputHotKeys : Singleton<InputHotKeys>
{
    protected bool isToogleInvUI = false;
    public bool IsToogleInvUI => isToogleInvUI;
    
    protected bool isToogleShopUI = false;
    public bool IsToogleShopUI => isToogleShopUI;
    
    protected bool isTooleTowerUI = false;
    public bool IsTooleTowerUI => isTooleTowerUI;
    
    protected bool isTooleStatusUI = false;
    public bool IsTooleStatusUI => isTooleStatusUI;
    
    protected bool isSettings = false;
    public bool IsSettings => isSettings;
    
    protected KeyCode keyCode;
    public KeyCode KeyCode => keyCode;

    protected virtual void Update()
    {
        this.OpenInventory();
        this.ToogleNumber();
        this.OpenTowerUpgarde();
        this.OpenShop();
        this.OpenStatus();
        this.Settings();
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
        isToogleInvUI = Input.GetKeyUp(KeyCode.G);
    }
    public virtual void OpenShop()
    {
        isToogleShopUI = Input.GetKeyUp(KeyCode.F);
    }
    public virtual void OpenTowerUpgarde()
    {
        isTooleTowerUI = Input.GetKeyUp(KeyCode.E);
    }
    public virtual void OpenStatus()
    {
       isTooleStatusUI = Input.GetKeyUp(KeyCode.Q);
    }
    public virtual void Settings()
    {
        isSettings = Input.GetKeyUp(KeyCode.R);
    }
}