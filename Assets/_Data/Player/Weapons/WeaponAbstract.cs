using UnityEngine;

public abstract class WeaponAbstract : MyMonoBehaviour
{
    [SerializeField] protected AttackPoint attackPoint;
    public AttackPoint AttackPoint => attackPoint;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadAttackPoint();
    }

    protected virtual void LoadAttackPoint()
    {
        if (attackPoint != null) return;
        attackPoint = GetComponentInChildren<AttackPoint>();
        Debug.Log(transform.name + "LoadAttackPoint",gameObject);
    }
}
