using System;
using UnityEngine;

public class BulletProjectile : MyMonoBehaviour
{
    
    private Rigidbody bulletRigidBody;
   
    protected override void Awake()
    {
        base.Awake();
        bulletRigidBody = GetComponent<Rigidbody>();
    }

    protected override void Start()
    {
        base.Start();
        float speed = 10f;
        bulletRigidBody.linearVelocity = transform.forward * speed;
    }
    
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("OnTriggerEnter: "+other.name);
        Destroy(gameObject);
    }
}
