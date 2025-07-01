using System;
using StarterAssets;
using UnityEngine;

public class InputManager : Singleton<InputManager>
{
    
    [SerializeField]private bool isLeftClick = false;
    [SerializeField]private bool isRightClick =  false;
    //Check Shoot
    [SerializeField]private bool isSlowShoot = false;
   

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
        
        this.isLeftClick = Input.GetMouseButton(0);
    }
    
    
    // ReSharper disable Unity.PerformanceAnalysis
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
        return this.isLeftClick;
    }

    
    
}
