using System;
using UnityEngine;

public class NormalCrosshair : CrosshairAbstract
{
    [SerializeField]private float distanceToPoint = 10f;
    
    protected override void Pointing()
    {
        transform.position = mainCamera.transform.position + mainCamera.transform.forward * distanceToPoint;
        
    }
    
}
