using System;
using UnityEngine;

public abstract class PlayerAbstract : MyMonoBehaviour
{
    [SerializeField]protected PlayerCtrl playerCtrl;
    [SerializeField]protected CrosshairUI crosshairUI;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadPlayerCtrl();
        LoadCrosshairUI();
    }
    protected virtual void LoadPlayerCtrl()
    {
        if(playerCtrl != null) return;
        playerCtrl = transform.GetComponentInParent<PlayerCtrl>();
        Debug.Log(transform.name+" : LoadPlayerCtrl",gameObject);
        
    }
    protected virtual void LoadCrosshairUI()
    {
        if(crosshairUI != null) return;
        crosshairUI = FindAnyObjectByType<CrosshairUI>();
        Debug.Log(transform.name+" : LoadCrosshairUI",gameObject);
        
    }
    protected virtual CrosshairAbstract GetCrosshair(int index)
    {
        return playerCtrl.CrosshairCtrl.GetCrosshair(index);
    }
}
