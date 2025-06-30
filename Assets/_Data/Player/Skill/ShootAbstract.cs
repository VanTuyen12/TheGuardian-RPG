using UnityEngine;

public abstract class ShootAbstract : MyMonoBehaviour
{
    [SerializeField]protected PlayerCtrl playerCtrl;
    
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
