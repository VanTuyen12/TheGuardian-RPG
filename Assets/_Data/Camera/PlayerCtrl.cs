using StarterAssets;
using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.Animations.Rigging;

    public class PlayerCtrl : MyMonoBehaviour
    {
        [SerializeField] CinemachineVirtualCamera  aimVirtualCamera;
        public CinemachineVirtualCamera AimVirtualCamera => aimVirtualCamera;
        [SerializeField] StarterAssetsInputs  starterAssetsInputs;
        public StarterAssetsInputs StarterAssetsInputs => starterAssetsInputs;
        [SerializeField] protected Transform model;
        [SerializeField] protected ThirdPersonController  thirdPersonCtrl;
        public ThirdPersonController ThirdPersonCtrl => thirdPersonCtrl;
   
        [SerializeField] protected CrosshairPointer crosshairPointer;
        public CrosshairPointer CrosshairPointer => crosshairPointer;
   
        //[SerializeField] Transform pfBulletProjectile;
        //[SerializeField] SpawnBulletPosition spawnBulletPosition;
        [SerializeField] private Animator animator;
        public Animator Animator => animator;
        [SerializeField] private RigBuilder rigBuilder;
        [SerializeField] private Rig rig;
        public Rig Rig => rig;
   
   
        protected virtual void FaceTheTargetInstant(Vector3 mouseWorldPosition)
        {
            Vector3 worldAimTarget = mouseWorldPosition;
            worldAimTarget.y = transform.position.y;
            Vector3 aimDirection = (worldAimTarget - this.transform.position).normalized;
            transform.forward = aimDirection; // Quay ngay lập tức
        }

        /*protected virtual void Shooting()
    {

        if (starterAssetsInputs.shoot)
        {
            //UpdateAimingWeights();
            FaceTheTargetInstant(mouseWorldPosition);
            
            
            Vector3 aimDir = (mouseWorldPosition - spawnBulletPosition.transform.position).normalized;
            Instantiate(pfBulletProjectile, spawnBulletPosition.transform.position,
                Quaternion.LookRotation(aimDir, Vector3.up));
            starterAssetsInputs.shoot = false;
        }
        
    }*/

        protected override void LoadComponents()
        {
            base.LoadComponents();
            this.LoadCinemachineVirtualCamera();
            this.LoadStarterAssetsInputs();
            this.LoadThirdPersonController();
            this.LoadAnimator();
            this.LoadRigBuilder();
            this.LoadCrosshairPointer();
            this.LoadModel();
        }
    
        protected virtual void LoadModel()
        {
            if (model != null) return;
            model = transform.Find("Geometry/Model");
            //spawnBulletPosition = model.GetComponentInChildren<SpawnBulletPosition>();
            Debug.Log(transform.name+": LoadModel",gameObject);
        }
        protected virtual void LoadCrosshairPointer()
        {
            if (crosshairPointer != null) return;
            crosshairPointer = GetComponentInChildren<CrosshairPointer>();
            Debug.Log(transform.name+": LoadCrosshairPointer",gameObject);
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

