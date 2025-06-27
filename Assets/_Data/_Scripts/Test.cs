using UnityEngine;
using System;
using StarterAssets;
using Unity.Cinemachine;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Animations.Rigging;
using UnityEngine.Serialization;
namespace _Data._Scripts
{
    public class Test : MyMonoBehaviour
    {
         [SerializeField] CinemachineVirtualCamera  aimVirtualCamera;
   [SerializeField] StarterAssetsInputs  starterAssetsInputs;
   [SerializeField] protected Transform model;
   [SerializeField] ThirdPersonController  thirdPersonCtrl;
   [SerializeField] private float normalSensitivity = 1f ;
   [SerializeField] private float aimlSensitivity = 0.5f;
   [SerializeField] private LayerMask aimColLayerMask;
   [SerializeField] private Transform centerTarget;
   
   [SerializeField] Transform pfBulletProjectile;
   [SerializeField] AttackPoint attackPoint;
   [SerializeField] private Animator animator;
   [SerializeField] private RigBuilder rigBuilder;
   [SerializeField] private Rig rig;
   [SerializeField] private bool isAiming = false;
   private Vector3 mouseWorldPosition = Vector3.zero;
 
   protected override void Awake()
   {
       base.Awake();
       //animator = GetComponent<Animator>();
       
   }

   void Update()
    {
        this.LookAtCrosshair();
        this.CheckAimInputs();
        //this.CheckSooting();
        this.Shooting();
        
    }
   

    protected virtual void CheckAimInputs()
    {
        bool shouldAim = starterAssetsInputs.aim;
        if (shouldAim && !isAiming)
        {
            isAiming = true;
            aimVirtualCamera.gameObject.SetActive(true);
            thirdPersonCtrl.SetSensitivity(aimlSensitivity);
            thirdPersonCtrl.SetRotateOnMove(false);
            
        }
        if (!shouldAim && isAiming)
        {
            isAiming = false;
            aimVirtualCamera.gameObject.SetActive(false);
            thirdPersonCtrl.SetSensitivity(normalSensitivity);
            thirdPersonCtrl.SetRotateOnMove(true);
           
        }
        UpdateAimingWeights();
    }

    
    private void UpdateAimingWeights()
    {
        float targetRigWeight = isAiming ? 1f : 0f;
        float targetLayerWeight = isAiming ? 1f : 0f;
        
        if (isAiming)
        {
            rig.weight = Mathf.MoveTowards(rig.weight, targetRigWeight, Time.deltaTime * 5f);
            animator.SetLayerWeight(1, Mathf.MoveTowards(animator.GetLayerWeight(1), targetLayerWeight, Time.deltaTime * 5f));
    
            this.FaceTheTarget(mouseWorldPosition,20f);
        }
        else
        {
            rig.weight = Mathf.MoveTowards(rig.weight, 0f, Time.deltaTime * 6);
            if (rig.weight < 0.1f)
            {
                animator.SetLayerWeight(1, Mathf.MoveTowards(animator.GetLayerWeight(1), 0f, Time.deltaTime * 5f));
            }
        }
    }

    protected virtual void LookAtCrosshair()
    {
       
        Vector2 screenCenterPoint = new Vector2(Screen.width / 2, Screen.height / 2);
        Ray ray = Camera.main.ScreenPointToRay(screenCenterPoint);
        if (Physics.Raycast(ray, out RaycastHit hit,Mathf.Infinity, aimColLayerMask, QueryTriggerInteraction.Ignore))
        {
            centerTarget.position = hit.point;
            mouseWorldPosition = hit.point;
            //Debug.Log("Point:" + hit.collider.name);
            Debug.DrawLine(Camera.main.transform.position, hit.point, Color.red);
        }
    }

    protected virtual void FaceTheTarget(Vector3 mouseWorldPosition, float speed)
    {
       
        Vector3 worldAimTarget = mouseWorldPosition;
        worldAimTarget.y = transform.position.y;
        Vector3 aimDirection = (worldAimTarget - this.transform.position).normalized;
        transform.forward = Vector3.Lerp(transform.forward, aimDirection,Time.deltaTime * speed);
    }
    
    protected virtual void FaceTheTargetInstant(Vector3 mouseWorldPosition)
    {
        Vector3 worldAimTarget = mouseWorldPosition;
        worldAimTarget.y = transform.position.y;
        Vector3 aimDirection = (worldAimTarget - this.transform.position).normalized;
        transform.forward = aimDirection; // Quay ngay lập tức
    }

    protected virtual void Shooting()
    {

        if (starterAssetsInputs.shoot)
        {
            UpdateAimingWeights();
            FaceTheTargetInstant(mouseWorldPosition);
            
            
            Vector3 aimDir = (mouseWorldPosition - attackPoint.transform.position).normalized;
            Instantiate(pfBulletProjectile, attackPoint.transform.position,
                Quaternion.LookRotation(aimDir, Vector3.up));
            starterAssetsInputs.shoot = false;
        }
        
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadCinemachineVirtualCamera();
        this.LoadStarterAssetsInputs();
        this.LoadThirdPersonController();
        this.LoadAnimator();
        this.LoadRigBuilder();
        this.LoadCenterTarget();
        this.LoadModel();
    }
    
    protected virtual void LoadModel()
    {
        if (model != null) return;
        model = GameObject.Find("Model").transform;
        attackPoint = model.GetComponentInChildren<AttackPoint>();
        Debug.Log(transform.name+": LoadModel",gameObject);
    }
    protected virtual void LoadCenterTarget()
    {
        if (centerTarget != null) return;
        centerTarget = GameObject.Find("CenterTarget").gameObject.transform;
        Debug.Log(transform.name+": LoadCenterTarget",gameObject);
    }
    protected virtual void LoadRigBuilder()
    {
        if (rigBuilder != null) return;
        rigBuilder = GetComponent<RigBuilder>();
        if (rig == null && rigBuilder.layers.Count > 0)
        {
            rig = rigBuilder.layers[0].rig;
        }
        Debug.Log(transform.name+": LoadRigBuilder",gameObject);
    }
    
    protected virtual void LoadThirdPersonController()
    {
        if (thirdPersonCtrl != null) return;
        thirdPersonCtrl = GetComponent<ThirdPersonController>();
        Debug.Log(transform.name+": LoadThirdPersonController",gameObject);
    }
    [Obsolete("Obsolete")]
    
    protected virtual void LoadCinemachineVirtualCamera()
    {
        if (aimVirtualCamera != null) return;
        aimVirtualCamera =GameObject.Find("PlayerAimCamera").GetComponent<CinemachineVirtualCamera>();
        Debug.Log(transform.name+": aimVirtualCamera",gameObject);
    }
   
    protected virtual void LoadAnimator()
    {
        if (animator != null) return;
        animator = GetComponent<Animator>();
        Debug.Log(transform.name+": LoadAnimator",gameObject);
    }
    protected virtual void LoadStarterAssetsInputs()
    {
        if (starterAssetsInputs != null) return;
        starterAssetsInputs = GetComponent<StarterAssetsInputs>();
        Debug.Log(transform.name+": LoadStarterAssetsInputs",gameObject);
    }

    }
}