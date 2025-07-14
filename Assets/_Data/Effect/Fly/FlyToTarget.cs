using System;
using UnityEngine;

public class FlyToTarget : MyMonoBehaviour
{  
    [SerializeField]protected float speed = 25f;
    [SerializeField]protected Transform target;
    [SerializeField]protected Rigidbody rigBullet;

    protected override void Start()
    {
        rigBullet = transform.parent.GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        this.Flying();
    }

    public virtual void SetTarget(Transform _target)
    {
        this.target = _target;
        transform.parent.LookAt(_target);
    }
    
    protected virtual void Flying()
    {
        if (target == null) return;
        rigBullet.linearVelocity = transform.parent.forward * speed;
        //transform.parent.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}
