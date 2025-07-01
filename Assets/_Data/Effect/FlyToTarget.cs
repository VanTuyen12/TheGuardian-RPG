using System;
using UnityEngine;

public class FlyToTarget : MyMonoBehaviour
{   [SerializeField]protected Transform target;
    [SerializeField]protected float speed = 10f;
    private void Update()
    {
        this.Flying();
    }

    public virtual void SetTarget(Transform _target)
    {
        this.target = _target;
        transform.parent.LookAt(this.target);
    }
    
    protected virtual void Flying()
    {
        if (target == null) return;
        transform.parent.GetComponent<Rigidbody>().linearVelocity = Vector3.forward * speed;
        //transform.parent.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}
