using UnityEngine;

public class BossDamageRecevier : EnemyDamageRecevier
{
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
