    using System;
    using StarterAssets;
    using UnityEngine;

    public class PlayerAiming : PlayerAbstract
    {
        
        
        [SerializeField] private float normalSensitivity = 1f ;
        [SerializeField] private float aimlSensitivity = 0.5f;
        [SerializeField] private bool isAiming = false;
        
        protected override void Awake()
        {
            base.Awake();
            playerCtrl.PlayerActionCtrl.SetCrosshairState(false);;
            
        }

        protected virtual void Update()
        {
            CheckAimInputs();
            MoveAiming();
        }
        
        protected virtual void CheckAimInputs()
        {   
            bool shouldAim = InputManager.Instance.IsAiming();
            if (shouldAim && !isAiming)
            {
                isAiming = true;
                playerCtrl.AimVirtualCamera.gameObject.SetActive(true);
                playerCtrl.ThirdPersonCtrl.SetSensitivity(aimlSensitivity);
                playerCtrl.ThirdPersonCtrl.SetRotateOnMove(false);
                playerCtrl.PlayerActionCtrl.SetCrosshairState(true);
            }
            if (!shouldAim && isAiming)
            {
                isAiming = false;
                playerCtrl.AimVirtualCamera.gameObject.SetActive(false);
                playerCtrl.ThirdPersonCtrl.SetSensitivity(normalSensitivity);
                playerCtrl.ThirdPersonCtrl.SetRotateOnMove(true);
                playerCtrl.PlayerActionCtrl.SetCrosshairState(false);
           
            }
        }

        // ReSharper disable Unity.PerformanceAnalysis
        protected virtual void MoveAiming()
        {
            playerCtrl.PlayerActionCtrl.UpdateRigAndLayer(isAiming);
            playerCtrl.PlayerActionCtrl.FaceTarget(targetCrosshair.transform,isAiming);
        }
        /*public void SetCrosshairState(bool isAttack)
        {
            // Switch crosshair
            if (normalCrosshair != null)
                normalCrosshair.SetActive(!isAttack);
            
            if (targetCrosshair != null)
                targetCrosshair.SetActive(isAttack);
            
            Debug.Log($"Crosshair switched to: {(isAttack ? "Aiming" : "Normal")} mode");
        }*/
        
        /*public void StartAiming()
        {
            SetCrosshairState(true);
        }
    
        public void StopAiming()
        {
            SetCrosshairState(false);
        }
        
        private void UpdateAimingWeights(bool isAttack)
        {
            float targetRigWeight = isAttack ? 1f : 0f;
            float targetLayerWeight = isAttack ? 1f : 0f;
            
            if (isAttack)
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
        
        protected virtual void FaceTheTarget(bool isAttack)
        {
            if(!isAttack) return;
            TargetCrosshair targetCrosshair = playerCtrl.TargetCrosshair;
            Vector3 worldAimTarget = targetCrosshair.transform.position;
            worldAimTarget.y = playerCtrl.transform.position.y;
            Vector3 aimDirection = (worldAimTarget - this.playerCtrl.transform.position).normalized;
            playerCtrl.transform.forward = Vector3.Lerp(playerCtrl.transform.forward, aimDirection,Time.deltaTime * 20f);
        }*/
    }

