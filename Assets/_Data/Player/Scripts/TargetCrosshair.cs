using UnityEngine;

public class TargetCrosshair : MyMonoBehaviour
{
    [SerializeField] protected LayerMask aimColLayerMask = 1 << 0;
    
    private Vector2 screenCenterPoint;
    private Camera mainCamera;
    private Ray ray;
    private RaycastHit hit;
    protected override void Awake()
    {
        base.Awake();
        mainCamera =  Camera.main; 
        screenCenterPoint = new Vector2(Screen.width / 2, Screen.height / 2);
    }
    
    protected virtual void Update()
    {
        Pointing();
    }
    
    protected virtual void Pointing()
    {
        ray = mainCamera.ScreenPointToRay(screenCenterPoint);
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, aimColLayerMask, QueryTriggerInteraction.Ignore))
        {
            transform.position = hit.point;
            //Debug.Log("Point:" + hit.collider.name);
            Debug.DrawLine(mainCamera.transform.position, hit.point, Color.red);
        }
    }
}
