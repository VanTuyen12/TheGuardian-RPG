using UnityEngine;
using UnityEngine.Animations.Rigging;

public class PlayerActionCtrl : PlayerAbstract
{
    [SerializeField] protected CrosshairAbstract normalCrosshair;
    [SerializeField] protected CrosshairAbstract targetCrosshair;
    
    [Header("Setting Action")]
    [SerializeField] private float rigTransitionSpeed = 5f;
    [SerializeField] private float layerTransitionSpeed = 5f;
    [SerializeField] private float rigDisableSpeed = 15f;
    [SerializeField] private float rotationSpeed = 20f;
    
    [Header("Aim/Idle Transition Speeds")]
    [SerializeField] private float idleDisableSpeed = 15f; 
    [SerializeField] private float idleEnableSpeed = 8f;
    
    private bool isShootingMode = false;
    private bool isAimingMode = false;
    private bool isLastState = false;

    protected override void Awake()
    {
        base.Awake();
        normalCrosshair = GetCrosshair(0);
        targetCrosshair = GetCrosshair(1);
        playerCtrl.PlayerActionCtrl.SetCrosshairState(false);
    }
    
    protected virtual void Update()
    {
        UpdateMoveToAttack();
    }

    protected virtual void UpdateMoveToAttack()
    {
        bool shouldActivateRig = isShootingMode || isAimingMode;
        UpdateIdleRigAndLayer(shouldActivateRig);
        UpdateAimRigAndLayer(shouldActivateRig);
        
        if (shouldActivateRig)
        {
            FaceTarget(true);
        }
    }

    protected virtual void UpdateIdleRigAndLayer(bool isIdle)
    {
        float idleRigWeight = isIdle ? 0f : 1f;
        float idleLayerWeight = isIdle ? 0f : 1f;
        
        if (isIdle)
        {
            playerCtrl.GetRig(1).weight = Mathf.MoveTowards(playerCtrl.GetRig(1).weight, idleRigWeight, Time.deltaTime * idleDisableSpeed);
            playerCtrl.Animator.SetLayerWeight(2, Mathf.MoveTowards(playerCtrl.Animator.GetLayerWeight(2), idleLayerWeight, Time.deltaTime * idleDisableSpeed));
        }
        else
        {
            playerCtrl.GetRig(1).weight = Mathf.MoveTowards(playerCtrl.GetRig(1).weight, 1f, Time.deltaTime * idleEnableSpeed);
            playerCtrl.Animator.SetLayerWeight(2, Mathf.MoveTowards(playerCtrl.Animator.GetLayerWeight(2), 1f, Time.deltaTime * idleEnableSpeed));
        }
            
    }
    protected virtual void UpdateAimRigAndLayer(bool isAttack)
    {
        
        float aimRigWeight = isAttack ? 1f : 0f;
        float aimLayerWeight = isAttack ? 1f : 0f;
        
       
            
        if (isAttack)
        {
            //playerCtrl.Animator.SetLayerWeight(2, 0);
            playerCtrl.GetRig(0).weight = Mathf.MoveTowards(playerCtrl.GetRig(0).weight, 
                aimRigWeight, Time.deltaTime * rigTransitionSpeed);
            
            playerCtrl.Animator.SetLayerWeight(1, Mathf.MoveTowards( playerCtrl.Animator.GetLayerWeight(1), 
                aimLayerWeight, Time.deltaTime * layerTransitionSpeed));
        }
        else
        {
            playerCtrl.GetRig(0).weight = Mathf.MoveTowards(playerCtrl.GetRig(0).weight, 
                0f, Time.deltaTime * rigDisableSpeed);
            
            if (playerCtrl.GetRig(0).weight < 0.1f)
            {
                playerCtrl.Animator.SetLayerWeight(1, Mathf.MoveTowards( 
                    playerCtrl.Animator.GetLayerWeight(1), 0f, Time.deltaTime * layerTransitionSpeed));
            }
            //playerCtrl.Animator.SetLayerWeight(2, 1);
        }
    }
    
    public virtual void FaceTarget(bool isAttack)
    {
        if(!isAttack) return;
        CrosshairAbstract crosshair = GetCrosshair(1);
        Transform mySelf = playerCtrl.transform;
        
        Vector3 worldTarget = crosshair.transform.position;
        worldTarget.y = mySelf.position.y;
        Vector3 aimDirection = (worldTarget - mySelf.position).normalized;
        //mySelf.forward = aimDirection;
        mySelf.forward = Vector3.Lerp(mySelf.forward, aimDirection,Time.deltaTime * rotationSpeed);
    }
    
    public void SetShootingMode(bool shooting)
    {
        if (isShootingMode == shooting ) return;
       
        isShootingMode = shooting;
        UpdatePlayerState();
    }
    
    public void SetAimingMode(bool aiming)
    {
        if (isAimingMode == aiming ) return;
        
        isAimingMode = aiming;
        UpdatePlayerState();
    }
    
    private void UpdatePlayerState()
    {
        bool showTargetCrosshair = isShootingMode || isAimingMode;
        if (showTargetCrosshair == isLastState) return;
        
        isLastState = showTargetCrosshair;
        SetCrosshairState(showTargetCrosshair);
    }
    
    public void SetCrosshairState(bool isAttack)
    {
        // Switch crosshair
        if (normalCrosshair != null)
            normalCrosshair.gameObject.SetActive(!isAttack);

        if (targetCrosshair != null)
            targetCrosshair.gameObject.SetActive(isAttack);
        
        
        //Debug.Log($"Crosshair switched to: {(isAttack ? "target" : "Normal")} mode");
    }

    
    
}
