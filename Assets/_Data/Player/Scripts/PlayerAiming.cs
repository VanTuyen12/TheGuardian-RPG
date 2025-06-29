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
            playerCtrl.PlayerActionCtrl.FaceTarget(GetCrosshair(1),isAiming);
        }
    }

