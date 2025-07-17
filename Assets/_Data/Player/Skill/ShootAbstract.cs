using System;
using UnityEngine;

public abstract class ShootAbstract : MyMonoBehaviour
{
    [SerializeField]protected PlayerCtrl playerCtrl;
    [SerializeField] protected EffectSpawner effectSpawner;
    [SerializeField] protected EffectPrefabs effectPrefabs;
    
    protected virtual void Update()
    {
        Shooting();
    }
    protected abstract void Shooting();

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadPlayerCtrl();
        this.LoadEffectSpawner();
    }
    
   
    protected virtual void LoadEffectSpawner()
    {
        if(effectSpawner != null) return;
        effectSpawner = GameObject.Find("EffectSpawner").GetComponent<EffectSpawner>();
        effectPrefabs = GameObject.Find("EffectPrefabs").GetComponent<EffectPrefabs>();
        //effectPrefabs = effectSpawner.GetComponentInChildren<EffectPrefabs>();
        Debug.Log(transform.name+" : LoadEffect",gameObject);
        
    }
    
    protected virtual void LoadPlayerCtrl()
    {
        if(playerCtrl != null) return;
        playerCtrl = transform.GetComponentInParent<PlayerCtrl>();
        Debug.Log(transform.name+" : LoadPlayerCtrl",gameObject);
        
    }
    
    public virtual AttackPoint GetAttackPoint()
    {
        return playerCtrl.Weapons.GetCurrentWeapon(0).AttackPoint;
    }
}
