
    using System;
    using StarterAssets;
    using UnityEngine;

    public class PlayerAiming : PlayerAbstract
    {
        
        [SerializeField] private float normalSensitivity = 1f ;
        [SerializeField] private float aimlSensitivity = 0.5f;
        [SerializeField] private bool isAiming = false;
        [SerializeField] protected GameObject normalCrosshair;
        [SerializeField] protected GameObject aimingCrosshair;

        protected override void Awake()
        {
            base.Awake();
            normalCrosshair = playerCtrl.NormalCrosshair.gameObject;
            aimingCrosshair = playerCtrl.AimingCrosshair.gameObject;
            SetCrosshairState(false);
            
        }

        protected virtual void Update()
        {
            CheckAimInputs();
            FaceTheTarget();
            UpdateAimingWeights();
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
            SetCrosshairState(isAiming);
        }
        
        private void SetCrosshairState(bool aiming)
        {
            isAiming = aiming;
            
            // Switch crosshair
            if (normalCrosshair != null)
                normalCrosshair.SetActive(!aiming);
            
            if (aimingCrosshair != null)
                aimingCrosshair.SetActive(aiming);
            
            Debug.Log($"Crosshair switched to: {(aiming ? "Aiming" : "Normal")} mode");
        }
        
        public void StartAiming()
        {
            SetCrosshairState(true);
        }
    
        public void StopAiming()
        {
            SetCrosshairState(false);
        }
        
        private void UpdateAimingWeights()
        {
            float targetRigWeight = isAiming ? 1f : 0f;
            float targetLayerWeight = isAiming ? 1f : 0f;
            
            if (isAiming)
            {
                playerCtrl.Rig.weight = Mathf.MoveTowards(playerCtrl.Rig.weight, targetRigWeight, Time.deltaTime * 20f);
                playerCtrl.Animator.SetLayerWeight(1, Mathf.MoveTowards( playerCtrl.Animator.GetLayerWeight(1), 
                    targetLayerWeight, Time.deltaTime * 20f));
            }
            else
            {
                playerCtrl.Rig.weight = Mathf.MoveTowards(playerCtrl.Rig.weight, 0f, Time.deltaTime * 22);
                if (playerCtrl.Rig.weight < 0.1f)
                {
                    playerCtrl.Animator.SetLayerWeight(1, Mathf.MoveTowards( 
                        playerCtrl.Animator.GetLayerWeight(1), 0f, Time.deltaTime * 20f));
                }
            }
        }
        
        protected virtual void FaceTheTarget()
        {
            if(!isAiming) return;
            NormalCrosshair normalCrosshair = playerCtrl.NormalCrosshair;
            Vector3 worldAimTarget = normalCrosshair.transform.position;
            worldAimTarget.y = playerCtrl.transform.position.y;
            Vector3 aimDirection = (worldAimTarget - this.playerCtrl.transform.position).normalized;
            playerCtrl.transform.forward = Vector3.Slerp(playerCtrl.transform.forward, aimDirection,Time.deltaTime * 10f);
            
        }
        
        
    }

