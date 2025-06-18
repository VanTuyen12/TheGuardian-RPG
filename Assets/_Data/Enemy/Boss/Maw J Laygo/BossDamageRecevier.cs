using UnityEngine;

public class BossDamageRecevier : EnemyDamageRecevier
{
    protected override void LoadCapsuleCollider()
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
