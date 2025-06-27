using StarterAssets;
using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.Animations.Rigging;

    public class PlayerCtrl : MyMonoBehaviour
    {
        [SerializeField] CinemachineCamera  aimVirtualCamera;
        public CinemachineCamera AimVirtualCamera => aimVirtualCamera;
        [SerializeField] protected Transform model;
        [SerializeField] protected ThirdPersonController  thirdPersonCtrl;
        public ThirdPersonController ThirdPersonCtrl => thirdPersonCtrl;
   
        [SerializeField] protected NormalCrosshair normalCrosshair;
        public NormalCrosshair NormalCrosshair => normalCrosshair;
        
        [SerializeField] protected AimingCrosshair aimingCrosshair;
        public AimingCrosshair AimingCrosshair => aimingCrosshair;
   
        //[SerializeField] Transform pfBulletProjectile;
        //[SerializeField] SpawnBulletPosition spawnBulletPosition;
        [SerializeField] private Animator animator;
        public Animator Animator => animator;
        [SerializeField] private RigBuilder rigBuilder;
        [SerializeField] private Rig rig;
        public Rig Rig => rig;
        
        [SerializeField]protected Weapons weapons;
        public Weapons Weapons => weapons;
        
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
            this.LoadCinemachineCamera();
            this.LoadThirdPersonController();
            this.LoadAnimator();
            this.LoadRigBuilder();
            this.LoadNormalCrosshair();
            this.LoadAimingCrosshair();
            this.LoadModel();
            this.LoadWeapons();
        }
        
        protected virtual void LoadWeapons()
        {
            if (weapons != null) return;
            weapons = GetComponentInChildren<Weapons>();
            Debug.Log(transform.name+": LoadWeapons",gameObject);
        }
        protected virtual void LoadModel()
        {
            if (model != null) return;
            model = transform.Find("Geometry/Model");
            //spawnBulletPosition = model.GetComponentInChildren<SpawnBulletPosition>();
            Debug.Log(transform.name+": LoadModel",gameObject);
        }
        protected virtual void LoadNormalCrosshair()
        {
            if (normalCrosshair != null) return;
            normalCrosshair = FindAnyObjectByType<NormalCrosshair>();
            Debug.Log(transform.name+": LoadNormalCrosshair",gameObject);
        }
        protected virtual void LoadAimingCrosshair()
        {
            if (aimingCrosshair != null) return;
            aimingCrosshair = FindAnyObjectByType<AimingCrosshair>();
            Debug.Log(transform.name+": LoadAimingCrosshair",gameObject);
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
    
        protected virtual void LoadCinemachineCamera()
        {
            if (aimVirtualCamera != null) return;
            aimVirtualCamera =GameObject.Find("PlayerAimCamera").GetComponent<CinemachineCamera>();
            Debug.Log(transform.name+": LoadCinemachineCamera",gameObject);
        }
   
        protected virtual void LoadAnimator()
        {
            if (animator != null) return;
            animator = GetComponent<Animator>();
            Debug.Log(transform.name+": LoadAnimator",gameObject);
        }
    }

