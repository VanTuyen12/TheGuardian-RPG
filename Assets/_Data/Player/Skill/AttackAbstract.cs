using UnityEngine;

public abstract class AttackAbstract : MyMonoBehaviour
{
    [SerializeField]protected PlayerCtrl playerCtrl;
    protected void Update()
    {
        Shooting();
    }
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

    protected virtual AttackPoint GetAttackPoint()
    {
        return playerCtrl.Weapons.GetCurrentWeapon().AttackPoint;
    }
}
