using UnityEngine;
[RequireComponent(typeof(CapsuleCollider))]
public class EnemyDamageRecevier : DamageRecevier
{
    [SerializeField]protected CapsuleCollider capsuleCollider;
    [SerializeField]protected EnemyCtrl enemyCtrl;
    [SerializeField]private float deaAfterTime = 1.5f;
    
    protected override void OnDead()
    {
        base.OnDead();
        enemyCtrl.Animator.SetBool("isDead",this.isDead);
        capsuleCollider.enabled= false;
        RewardOnDead();
        Invoke(nameof(Disappear), deaAfterTime);
    }

    protected virtual void Disappear()
    {
        enemyCtrl.Despawn.DoDespawn();
    }

    protected override void OnEnable()
    {
        base.OnEnable();
        capsuleCollider.enabled = true;
    }

    protected override void OnHurt()
    {
        base.OnHurt();
        enemyCtrl.Animator.SetTrigger("isHurt");
    }

    protected virtual void RewardOnDead()
    {
        ItemInventory item = new();
        item.itemProfile = InventoryManager.Instance.GetProfileByCode(ItemCode.Gold);
        item.itemCount = 10;
        
        InventoryManager.Instance.Monies().AddItem(item);
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
        capsuleCollider.radius = 0.5f;
        capsuleCollider.height = 1.4f;
        capsuleCollider.center = new Vector3(0, 1f, 0);
        Debug.Log(transform.name + " :LoadCapsuleCollider ",gameObject);
    }
}
