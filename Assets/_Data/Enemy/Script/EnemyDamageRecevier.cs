using UnityEngine;
[RequireComponent(typeof(CapsuleCollider))]
public class EnemyDamageRecevier : DamageRecevier
{
    [SerializeField]protected CapsuleCollider capsuleCollider;
    [SerializeField]protected EnemyCtrl enemyCtrl;
    protected override void OnDead()
    {
        base.OnDead();
        enemyCtrl.Animator.SetBool("isDead",this.isDead);
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadCapsuleCollider();
        this.LoadEnemyCtrl();
    }
    protected virtual void LoadEnemyCtrl()
    {
        if (enemyCtrl != null) return;
        enemyCtrl = this.GetComponentInParent<EnemyCtrl>();
        Debug.Log(transform.name + " :LoadEnemyCtrl ",gameObject);
    }
    protected virtual void LoadCapsuleCollider()
    {
        if (capsuleCollider != null) return;
        capsuleCollider = this.GetComponent<CapsuleCollider>();
        capsuleCollider.isTrigger = true;
        capsuleCollider.radius = 0.35f;
        capsuleCollider.height = 2f;
        capsuleCollider.center = new Vector3(0, 1, 0);
        Debug.Log(transform.name + " :LoadCapsuleCollider ",gameObject);
    }
}
