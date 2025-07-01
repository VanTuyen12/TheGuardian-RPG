using StarterAssets;
using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.Animations.Rigging;
using UnityEngine.InputSystem;

public class PlayerCtrl : MyMonoBehaviour
{
    [SerializeField] CinemachineCamera aimVirtualCamera;
    public CinemachineCamera AimVirtualCamera => aimVirtualCamera;
    [SerializeField] protected Transform model;
    [SerializeField] protected ThirdPersonController thirdPersonCtrl;
    public ThirdPersonController ThirdPersonCtrl => thirdPersonCtrl;

    [SerializeField] protected CrosshairCtrl crosshairCtrl;
    public CrosshairCtrl CrosshairCtrl => crosshairCtrl;

    [SerializeField] protected PlayerAiming playerAiming;
    public PlayerAiming PlayerAiming => playerAiming;
    [SerializeField] protected PlayerActionCtrl actionCtrl;
    public PlayerActionCtrl PlayerActionCtrl => actionCtrl;
    
    [SerializeField] private Animator animator;
    public Animator Animator => animator;
    [SerializeField] private RigBuilder rigBuilder;
    [SerializeField] private Rig rig;
    public Rig Rig => rig;

    [SerializeField] protected Weapons weapons;
    public Weapons Weapons => weapons;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadCinemachineCamera();
        this.LoadThirdPersonController();
        this.LoadAnimator();
        this.LoadRigBuilder();
        this.LoadCrosshairCtrl();
        this.LoadModel();
        this.LoadWeapons();
        this.LoadPlayerAiming();
        this.LoadPlayerActionCtrl();
    }
    protected virtual void LoadPlayerActionCtrl()
    {
        if (actionCtrl != null) return;
        actionCtrl = GetComponentInChildren<PlayerActionCtrl>();
        Debug.Log(transform.name + ": LoadPlayerActionCtrl", gameObject);
    }
    protected virtual void LoadPlayerAiming()
    {
        if (playerAiming != null) return;
        playerAiming = GetComponentInChildren<PlayerAiming>();
        Debug.Log(transform.name + ": LoadPlayerAiming", gameObject);
    }
    protected virtual void LoadAnimator()
    {
        if (animator != null) return;
        animator = GetComponent<Animator>();
        Debug.Log(transform.name + ": LoadAnimator", gameObject);
    }
    
    protected virtual void LoadWeapons()
    {
        if (weapons != null) return;
        weapons = GetComponentInChildren<Weapons>();
        Debug.Log(transform.name + ": LoadWeapons", gameObject);
    }

    protected virtual void LoadModel()
    {
        if (model != null) return;
        model = transform.Find("Geometry/Model");
        //spawnBulletPosition = model.GetComponentInChildren<SpawnBulletPosition>();
        Debug.Log(transform.name + ": LoadModel", gameObject);
    }

    protected virtual void LoadCrosshairCtrl()
    {
        if (crosshairCtrl != null) return;
        crosshairCtrl = FindAnyObjectByType<CrosshairCtrl>();
        Debug.Log(transform.name + ": LoadCrosshairCtrl", gameObject);
    }
    

    protected virtual void LoadRigBuilder()
    {
        if (rigBuilder != null) return;
        rigBuilder = GetComponent<RigBuilder>();
        if (rig == null && rigBuilder.layers.Count > 0)
        {
            rig = rigBuilder.layers[0].rig;
        }

        Debug.Log(transform.name + ": LoadRigBuilder", gameObject);
    }

    protected virtual void LoadThirdPersonController()
    {
        if (thirdPersonCtrl != null) return;
        thirdPersonCtrl = GetComponent<ThirdPersonController>();
        Debug.Log(transform.name + ": LoadThirdPersonController", gameObject);
    }

    protected virtual void LoadCinemachineCamera()
    {
        if (aimVirtualCamera != null) return;
        aimVirtualCamera = GameObject.Find("PlayerAimCamera").GetComponent<CinemachineCamera>();
        Debug.Log(transform.name + ": LoadCinemachineCamera", gameObject);
    }
}