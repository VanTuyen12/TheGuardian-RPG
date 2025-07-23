using UnityEngine;
using UnityEngine.Serialization;

public abstract class CrosshairAbstract : MyMonoBehaviour
{
    [SerializeField] protected Camera mainCamera;
    protected override void Awake()
    {
        base.Awake();
        mainCamera =  Camera.main; 
       
    }
    
    protected virtual void Update()
    {
        Pointing();
    }

    protected abstract void Pointing();
}
