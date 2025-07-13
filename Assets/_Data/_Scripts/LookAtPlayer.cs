using Unity.Cinemachine;
using UnityEngine;

public class LookAtPlayer : MyMonoBehaviour
{
    [SerializeField] GameObject playerCamera;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadPlayerCamera();
    }

    protected virtual void LoadPlayerCamera()
    {
        if (playerCamera != null) return;
        playerCamera = GameObject.Find("PlayerFollowCamera");
        Debug.Log(transform.name + " LoadPlayerCamera",gameObject);
    }
    
    void Update()
    {
        transform.LookAt(playerCamera.transform);
        transform.rotation = Quaternion.Euler(0,transform.rotation.eulerAngles.y + 180 ,0);
    }
}
