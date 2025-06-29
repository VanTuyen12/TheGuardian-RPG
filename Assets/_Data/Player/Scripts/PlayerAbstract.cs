using System;
using UnityEngine;

public abstract class PlayerAbstract : MyMonoBehaviour
{
    [SerializeField]protected PlayerCtrl playerCtrl;
    /*[SerializeField] protected GameObject normalCrosshair;
    [SerializeField] protected GameObject targetCrosshair;

    protected override void Awake()
    {
        normalCrosshair = playerCtrl.NormalCrosshair.gameObject;
        targetCrosshair = playerCtrl.TargetCrosshair.gameObject;
    }*/
    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadPlayerCtrl();
    }
    protected virtual void LoadPlayerCtrl()
    {
        if(playerCtrl != null) return;
        playerCtrl = transform.GetComponentInParent<PlayerCtrl>();
        Debug.Log(transform.name+" : LoadPlayerCtrl",gameObject);
        
    }

    protected virtual CrosshairAbstract GetCrosshair(int index)
    {
        return playerCtrl.CrosshairCtrl.GetCrosshair(index);
    }
}
