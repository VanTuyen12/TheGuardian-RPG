using System;
using UnityEngine;


public abstract class SkillsGunAbstract : MyMonoBehaviour
{
    [Header("Load Components")]
    [SerializeField]protected PlayerCtrl playerCtrl;
    [SerializeField] protected EffectSpawner effectSpawner;
    [SerializeField] protected EffectPrefabs effectPrefabs;
    

    protected int quantity = 1;
    
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

    protected virtual bool CheckBulletItem(ItemCode item)
    {
        InventoryCtrl itemInventory = InventoryManager.Instance.Items();
        ItemInventory bulletItem = itemInventory.FindItem(item);
        if (bulletItem == null) return false;
        return bulletItem.itemCount >= quantity;
    }
    
    protected virtual void SpawnEffect(string prefals, ItemCode item, int quantity,SoundName sfxName)
    {
        if(!CheckBulletItem(item)) return;
        
        AttackPoint attackPoint = GetAttackPoint();
        EffectCtrl newEffect = effectSpawner.Spawn( GetEffecct(prefals), attackPoint.transform.position);
        EffectFlyAbstract effectFly = (EffectFlyAbstract)newEffect;
        effectFly.FlyToTarget.SetTarget(playerCtrl.CrosshairCtrl.GetCrosshair(1).transform);
        newEffect.gameObject.SetActive(true);
        
        DuductItem(item, quantity);
        SpawnSoundSfx(sfxName);
    }

    protected virtual void DuductItem(ItemCode item,int quantity)
    {
        InventoryManager.Instance.RemoveItem(item, quantity);
    }
    
    protected virtual EffectCtrl GetEffecct(string effectName)
    {
        return effectPrefabs.GetByName(effectName);
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
    protected virtual void SpawnSoundSfx(SoundName sfxName)
    {
        var sfxPrefabs = SoundManager.Instance.CreateSfx(sfxName);
        sfxPrefabs.SetActive(true);
    }
}
