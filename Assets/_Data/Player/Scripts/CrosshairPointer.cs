using System;
using UnityEngine;

public class CrosshairPointer : MyMonoBehaviour
{
    [SerializeField] private LayerMask aimColLayerMask = 1 << 0;
    protected Vector3 mouseWorldPosition = Vector3.zero;
    public Vector3 MouseWorldPosition => mouseWorldPosition;
    protected virtual void Update()
    {
        Pointing();
    }
    
    protected virtual void Pointing()
    {
        Vector2 screenCenterPoint = new Vector2(Screen.width / 2, Screen.height / 2);
        Ray ray = Camera.main.ScreenPointToRay(screenCenterPoint);
        if (Physics.Raycast(ray, out RaycastHit hit,Mathf.Infinity, aimColLayerMask, QueryTriggerInteraction.Ignore))
        {
            transform.position = hit.point;
            mouseWorldPosition = hit.point;
            //Debug.Log("Point:" + hit.collider.name);
            Debug.DrawLine(Camera.main.transform.position, hit.point, Color.red);
        }
    }
}
