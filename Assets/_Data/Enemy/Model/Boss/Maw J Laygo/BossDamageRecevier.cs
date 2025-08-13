using UnityEngine;

public class BossDamageRecevier : EnemyDamageRecevier
{
    protected override void RewardOnDead()
    {
        base.RewardOnDead();
        
        var dropManager = ItemDropManager.Instance;
        var pos = transform.position;

        dropManager.DropMany(ItemCode.Gold, 5, pos, 50);
        dropManager.DropMany(ItemCode.PlayerExp, 1, pos, 50);
        dropManager.DropMany(ItemCode.Bullet1, 1, pos, 20);
        dropManager.DropMany(ItemCode.Bullet2, 2, pos, 10 );
    }

    protected override void LoadCapsuleCollider()
    {
        if (capsuleCollider != null) return;
        capsuleCollider = this.GetComponent<CapsuleCollider>();
        capsuleCollider.isTrigger = true;
        capsuleCollider.height = 1.9f;
        capsuleCollider.center = new Vector3(0, 1.1f, 0);
        Debug.Log(transform.name + " :LoadCapsuleCollider ",gameObject);
    }
}
