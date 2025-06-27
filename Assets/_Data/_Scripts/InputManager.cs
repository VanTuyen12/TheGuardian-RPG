using System;
using StarterAssets;
using UnityEngine;

public class InputManager : Singleton<InputManager>
{
    [SerializeField]protected StarterAssetsInputs assetsInputs;
    private bool isLeftClick = false;
    private bool isRightClick =  false;

    private void Update()
    {
        CheckRightClick();
        CheckLeftClick();
    }

    protected virtual void CheckRightClick()
    {
        this.isRightClick = assetsInputs.aim;
    }
    protected virtual void CheckLeftClick()
    {
        this.isLeftClick = assetsInputs.shoot;
    }

    public virtual bool IsAiming()
    {
        return this.isRightClick;
    }
    
    public virtual bool IsShooting()
    {
        return this.isLeftClick;
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadStarterAssetsInputs();
    }

    protected virtual void LoadStarterAssetsInputs()
    {
        if (assetsInputs != null) return;
        assetsInputs = FindAnyObjectByType<StarterAssetsInputs>();
        Debug.Log(transform.name+": LoadStarterAssetsInputs",gameObject);
    }
    
}
