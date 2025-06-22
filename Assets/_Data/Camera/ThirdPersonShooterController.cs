using System;
using Cinemachine;
using StarterAssets;
using UnityEngine;

public class ThirdPersonShooterController : MyMonoBehaviour
{
   [SerializeField] CinemachineVirtualCamera  aimVirtualCamera;
   [SerializeField] StarterAssetsInputs  starterAssetsInputs;
   [SerializeField] ThirdPersonController  thirdPersonCtrl;
   [SerializeField] private float normalSensitivity = 1f ;
   [SerializeField] private float aimlSensitivity = 0.5f;
   [SerializeField] private LayerMask aimColLayerMask;
   [SerializeField] private Transform target;
   private Vector3 mouseWorldPosition = Vector3.zero;
   [SerializeField] Transform pfBulletProjectile;
   [SerializeField] Transform spawnBulletPosition;
   Transform hitTransform = null;
   [SerializeField] private Transform red;
   [SerializeField] private Transform green;
    void Update()
    {
        this.LookAtCrosshair();
        this.CheckAimInputs();
        this.Shooting();
        
    }
    
    protected virtual void CheckAimInputs()
    {
        if (starterAssetsInputs.aim)
        {
            aimVirtualCamera.gameObject.SetActive(true);
            thirdPersonCtrl.SetSensitivity(aimlSensitivity);
            thirdPersonCtrl.SetRotateOnMove(false);
            
            this.FaceTheTarget(mouseWorldPosition);
        }
        else
        {
            aimVirtualCamera.gameObject.SetActive(false);
            thirdPersonCtrl.SetSensitivity(normalSensitivity);
            thirdPersonCtrl.SetRotateOnMove(true);
        }
    }
    
    protected virtual void LookAtCrosshair()
    {
       
        Vector2 screenCenterPoint = new Vector2(Screen.width / 2, Screen.height / 2);
        Ray ray = Camera.main.ScreenPointToRay(screenCenterPoint);
        if (Physics.Raycast(ray, out RaycastHit hit,Mathf.Infinity, aimColLayerMask, QueryTriggerInteraction.Ignore))
        {
            target.position = hit.point;
            mouseWorldPosition = hit.point;
            hitTransform = hit.transform;
            //Debug.Log("Point:" + hit.collider.name);
            Debug.DrawLine(Camera.main.transform.position, hit.point, Color.red);
           
        }
    }

    protected virtual void FaceTheTarget(Vector3 mouseWorldPosition)
    {
       
        Vector3 worldAimTarget = mouseWorldPosition;
        worldAimTarget.y = transform.position.y;
        Vector3 aimDirection = (worldAimTarget - this.transform.position).normalized;
        
        transform.forward = Vector3.Lerp(transform.forward, aimDirection,Time.deltaTime * 20f);
    }

    protected virtual void Shooting()
    {
        if (starterAssetsInputs.shoot)
        {
            if (hitTransform != null)
            {
                if (hitTransform.GetComponent<TargetTest>() != null)
                {
                    Instantiate(green,hitTransform.transform.position,Quaternion.identity);
                }
                else
                {
                    Instantiate(red,hitTransform.transform.position,Quaternion.identity);
                }
            }
            //Vector3 aimDir = (mouseWorldPosition - spawnBulletPosition.position).normalized;
            //Instantiate(pfBulletProjectile,spawnBulletPosition.position,Quaternion.LookRotation(aimDir,Vector3.up));
            starterAssetsInputs.shoot =  false;
        }
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadCinemachineVirtualCamera();
        this.LoadStarterAssetsInputs();
        this.LoadThirdPersonController();
    }
    protected virtual void LoadThirdPersonController()
    {
        if (thirdPersonCtrl != null) return;
        thirdPersonCtrl = GetComponent<ThirdPersonController>();
        Debug.Log(transform.name+": LoadThirdPersonController",gameObject);
    }
    protected virtual void LoadCinemachineVirtualCamera()
    {
        if (aimVirtualCamera != null) return;
        aimVirtualCamera =GameObject.Find("PlayerAimCamera").GetComponent<CinemachineVirtualCamera>();
        Debug.Log(transform.name+": aimVirtualCamera",gameObject);
    }
   
    protected virtual void LoadStarterAssetsInputs()
    {
        if (starterAssetsInputs != null) return;
        starterAssetsInputs = GetComponent<StarterAssetsInputs>();
        Debug.Log(transform.name+": LoadStarterAssetsInputs",gameObject);
    }
    
    
}
