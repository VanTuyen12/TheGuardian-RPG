using UnityEngine;


public abstract class DamageSender : MyMonoBehaviour
{
    [SerializeField]protected float damege = 10f;
    public float Damege => damege;

    protected virtual void SendDamege(DamageRecevier damageRecevier)
    {
        damageRecevier.Deduct(damege);
    }
}
