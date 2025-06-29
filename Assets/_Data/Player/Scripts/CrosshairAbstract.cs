using UnityEngine;

public abstract class CrosshairAbstract : MyMonoBehaviour
{
    [SerializeField] protected Camera mainCamera;
    protected Vector2 screenCenterPoint;
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

    protected abstract void Pointing();
}
