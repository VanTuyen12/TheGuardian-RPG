using UnityEngine;
using UnityEngine.Animations.Rigging;

public class PlayerActionCtrl : PlayerAbstract
{
    [SerializeField] private float rigTransitionSpeed = 20f;
    [SerializeField] private float layerTransitionSpeed = 20f;
    [SerializeField] private float rigDisableSpeed = 22f;
    [SerializeField] private float rotationSpeed = 20f;
    public void UpdateRigAndLayer(bool isAttack)
    {
        float rigWeight = isAttack ? 1f : 0f;
        float layerWeight = isAttack ? 1f : 0f;
            
        if (isAttack)
        {
            playerCtrl.Rig.weight = Mathf.MoveTowards(playerCtrl.Rig.weight, 
                rigWeight, Time.deltaTime * rigTransitionSpeed);
            
            playerCtrl.Animator.SetLayerWeight(1, Mathf.MoveTowards( playerCtrl.Animator.GetLayerWeight(1), 
                layerWeight, Time.deltaTime * layerTransitionSpeed));
        }
        else
        {
            playerCtrl.Rig.weight = Mathf.MoveTowards(playerCtrl.Rig.weight, 
                0f, Time.deltaTime * rigDisableSpeed);
            
            if (playerCtrl.Rig.weight < 0.1f)
            {
                playerCtrl.Animator.SetLayerWeight(1, Mathf.MoveTowards( 
                    playerCtrl.Animator.GetLayerWeight(1), 0f, Time.deltaTime * layerTransitionSpeed));
            }
        }
        
    }
    
    public virtual void FaceTarget(CrosshairAbstract crosshair,bool isAttack)
    {
        if(!isAttack) return;
        if (crosshair is null) return;
       
        Transform mySelf = playerCtrl.transform;
        
        Vector3 worldTarget = crosshair.transform.position;
        worldTarget.y = mySelf.position.y;
        Vector3 aimDirection = (worldTarget - mySelf.position).normalized;
        mySelf.forward = Vector3.Lerp(mySelf.forward, aimDirection,Time.deltaTime * rotationSpeed);
    }
    
    public void SetCrosshairState(bool isAttack)
    {
        CrosshairAbstract normalCrosshair = GetCrosshair(0);
        CrosshairAbstract targetCrosshair = GetCrosshair(1);
        
        // Switch crosshair
        if (normalCrosshair != null)
            normalCrosshair.gameObject.SetActive(!isAttack);
            
        if (targetCrosshair != null)
            targetCrosshair.gameObject.SetActive(isAttack);
            
        Debug.Log($"Crosshair switched to: {(isAttack ? "target" : "Normal")} mode");
    }
    
}
