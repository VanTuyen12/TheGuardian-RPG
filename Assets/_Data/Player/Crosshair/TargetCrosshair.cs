using UnityEngine;

public class TargetCrosshair : CrosshairAbstract
{
    [SerializeField] protected LayerMask aimColLayerMask = 1 << 0;
    private Ray ray;
    private RaycastHit hit;
    
    protected override void Pointing()
    {
        Vector2 screenCenterPoint = new Vector2(Screen.width / 2, Screen.height / 2);
        ray = mainCamera.ScreenPointToRay(screenCenterPoint);
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, aimColLayerMask, QueryTriggerInteraction.Ignore))
        {
            transform.position = hit.point;
            //Debug.Log("Point:" + hit.collider.name);
            Debug.DrawLine(mainCamera.transform.position, hit.point, Color.red);
        }
    }
}
