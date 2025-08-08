using System;
using UnityEngine;


public abstract class SkillsGunAbstract : MyMonoBehaviour
{
    [Header("Load Components")]
    [SerializeField]protected PlayerCtrl playerCtrl;
    [SerializeField] protected EffectSpawner effectSpawner;
    [SerializeField] protected EffectPrefabs effectPrefabs;
    [SerializeField]protected MouseCursorManager mouseCursor;

    protected int quantity = 1;
    
    protected virtual void Update()
    {
        if(mouseCursor.IsCursorVisible) return;
        Shooting();
    }
    protected abstract void Shooting();

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadPlayerCtrl();
        this.LoadEffectSpawner();
        this.LoadMouseCursor();
    }
    protected virtual void LoadMouseCursor()
    {
        if(mouseCursor != null) return;
        mouseCursor = FindAnyObjectByType<MouseCursorManager>();
        Debug.Log(transform.name+" : LoadMouseCursor",gameObject);
    }
    protected virtual void LoadEffectSpawner()
    {
        if(effectSpawner != null) return;
        effectSpawner = GameObject.Find("EffectSpawner").GetComponent<EffectSpawner>();
        effectPrefabs = GameObject.Find("EffectPrefabs").GetComponent<EffectPrefabs>();
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
        if (effectFly == null) return;
        if(playerCtrl == null) return;
        
        effectFly.DamageSender.SetDamage(GetDamageEffect());
        effectFly.FlyToTarget.SetTarget(playerCtrl.CrosshairCtrl.GetCrosshair(1).transform);
        newEffect.gameObject.SetActive(true);
        
        DuductItem(item, quantity);
        SpawnSoundSfx(sfxName);
    }
    protected abstract float GetDamageEffect();
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
