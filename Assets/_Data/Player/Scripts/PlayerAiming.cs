
    using System;
    using StarterAssets;
    using UnityEngine;

    public class PlayerAiming : PlayerAbstract
    {
        
        [SerializeField] private float normalSensitivity = 1f ;
        [SerializeField] private float aimlSensitivity = 0.5f;
        [SerializeField] private bool isAiming = false;
      
        protected virtual void Update()
        {
            CheckAimInputs();
        }
        
        
        protected virtual void CheckAimInputs()
        {
            bool shouldAim = playerCtrl.StarterAssetsInputs.aim;
            if (shouldAim && !isAiming)
            {
                isAiming = true;
                playerCtrl.AimVirtualCamera.gameObject.SetActive(true);
                playerCtrl.ThirdPersonCtrl.SetSensitivity(aimlSensitivity);
                playerCtrl.ThirdPersonCtrl.SetRotateOnMove(false);
                
            }
            if (!shouldAim && isAiming)
            {
                isAiming = false;
                playerCtrl.AimVirtualCamera.gameObject.SetActive(false);
                playerCtrl.ThirdPersonCtrl.SetSensitivity(normalSensitivity);
                playerCtrl.ThirdPersonCtrl.SetRotateOnMove(true);
           
            }
            UpdateAimingWeights();
        }
        
        private void UpdateAimingWeights()
        {
            float targetRigWeight = isAiming ? 1f : 0f;
            float targetLayerWeight = isAiming ? 1f : 0f;
        
            if (isAiming)
            {
                this.FaceTheTarget(playerCtrl.CrosshairPointer.MouseWorldPosition);
                playerCtrl.Rig.weight = Mathf.MoveTowards(playerCtrl.Rig.weight, targetRigWeight, Time.deltaTime * 5f);
                playerCtrl.Animator.SetLayerWeight(1, Mathf.MoveTowards( playerCtrl.Animator.GetLayerWeight(1), targetLayerWeight, Time.deltaTime * 5f));
               
            }
            else
            {
                playerCtrl.Rig.weight = Mathf.MoveTowards(playerCtrl.Rig.weight, 0f, Time.deltaTime * 6);
                if (playerCtrl.Rig.weight < 0.1f)
                {
                    playerCtrl.Animator.SetLayerWeight(1, Mathf.MoveTowards( playerCtrl.Animator.GetLayerWeight(1), 0f, Time.deltaTime * 5f));
                }
            }
        }
        
        protected virtual void FaceTheTarget(Vector3 mouseWorldPosition)
        {
       
            Vector3 worldAimTarget = mouseWorldPosition;
            worldAimTarget.y = transform.position.y;
            Vector3 aimDirection = (worldAimTarget - this.transform.position).normalized;
            transform.forward = Vector3.Slerp(transform.forward, aimDirection,Time.deltaTime * 50f);
        }

    }

