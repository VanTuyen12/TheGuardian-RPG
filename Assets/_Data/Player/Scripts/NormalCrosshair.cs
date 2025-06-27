using System;
using UnityEngine;

public class NormalCrosshair : MyMonoBehaviour
{
    [SerializeField] protected Camera mainCamera;
    [SerializeField]private float distanceToPoint = 10f;

    protected override void Awake()
    {
        base.Awake();
        mainCamera =  Camera.main;
    }
    
    protected virtual void Update()
    {
        Pointing();
    }
    
    protected virtual void Pointing()
    {
        transform.position = mainCamera.transform.position + mainCamera.transform.forward * distanceToPoint;
        
    }
    
}
