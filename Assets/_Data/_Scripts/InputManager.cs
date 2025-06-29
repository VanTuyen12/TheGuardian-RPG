using System;
using StarterAssets;
using UnityEngine;

public class InputManager : Singleton<InputManager>
{
    [SerializeField]protected StarterAssetsInputs assetsInputs;
    private bool isLeftClick = false;
    private bool isRightClick =  false;
    
    //Check Shoot
    [SerializeField]private bool isSlowShoot = false;
    [SerializeField]private bool isFastShoot  = false;

    private void Update()
    {
        CheckRightClick();
        CheckLeftClick();
        CheckShoot();
    }

    protected virtual void CheckRightClick()
    {
        this.isRightClick = assetsInputs.aim;
    }
    protected virtual void CheckLeftClick()
    {
        this.isLeftClick = assetsInputs.shoot;
    }

    protected virtual void CheckShoot()
    {
        if (isRightClick && isLeftClick) isSlowShoot =  true;
        else isSlowShoot = false;
        
        if (!isRightClick && isLeftClick) isFastShoot =  true;
        else isFastShoot = false;
        
    }
   
    public virtual void ResetShoot()
    {
        assetsInputs.shoot = false;
    }
    
    public virtual bool IsSlowShoot()
    {
        return this.isSlowShoot;
    }
    public virtual bool IsFastShoot()
    {
        return this.isFastShoot;
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
