using System;
using StarterAssets;
using UnityEngine;

public class InputManager : Singleton<InputManager>
{
    
    private bool isFastShoot = false;
    private bool isSlowShoot = false;
    //Check Shoot
    [SerializeField]private bool isRightClick =  false;

    private void Update()
    {
        CheckAiming();
        CheckFastShoot();
        CheckSlowShoot();
    }

    protected virtual void CheckAiming()
    {
        this.isRightClick = Input.GetMouseButton(1);
    }
    protected virtual void CheckFastShoot()
    {
        if(IsAiming()) return;
        this.isFastShoot = Input.GetMouseButton(0);
    }
    
    protected virtual void CheckSlowShoot()
    {
        if(!IsAiming()) return;
        isSlowShoot = Input.GetMouseButtonUp(0);
    }
    
    public virtual bool IsSlowShoot()
    {
        return this.isSlowShoot;
    }
    
    public virtual bool IsAiming()
    {
        return this.isRightClick;
    }
    
    public virtual bool IsFastShoot()
    {
        
        return this.isFastShoot;
    }

    
    
}
