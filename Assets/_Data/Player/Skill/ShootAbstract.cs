using UnityEngine;

public abstract class ShootAbstract : MyMonoBehaviour
{
    [SerializeField]protected PlayerCtrl playerCtrl;
    [SerializeField] protected bool isShooting = false;
    [SerializeField] protected bool isattacking = false;
    [SerializeField] protected float shotTimer = 0f;
    [SerializeField] protected float ceasefireTime = 5f;
    
    protected abstract void Shooting();

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

    
    
    
    public virtual AttackPoint GetAttackPoint()
    {
        return playerCtrl.Weapons.GetCurrentWeapon().AttackPoint;
    }
}
