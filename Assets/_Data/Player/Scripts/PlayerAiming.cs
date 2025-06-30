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
            //MoveAiming();
        }
        
        protected virtual void CheckAimInputs()
        {   
            bool shouldAim = InputManager.Instance.IsAiming();
            if (shouldAim && !isAiming)
            {
                isAiming = true;
                LookClose();
            }
            if (!shouldAim && isAiming)
            {
                isAiming = false;
                LookFar();
            }
            playerCtrl.PlayerActionCtrl.SetAimingMode(isAiming);
        }

        protected virtual void LookClose()
        {
            playerCtrl.AimVirtualCamera.gameObject.SetActive(true);
            playerCtrl.ThirdPersonCtrl.SetSensitivity(aimlSensitivity);
            playerCtrl.ThirdPersonCtrl.SetRotateOnMove(false);//camera zoom
           
        }
        
        protected virtual void LookFar()
        {
            playerCtrl.AimVirtualCamera.gameObject.SetActive(false);
            playerCtrl.ThirdPersonCtrl.SetSensitivity(normalSensitivity);
            playerCtrl.ThirdPersonCtrl.SetRotateOnMove(true);
            
        }
        // ReSharper disable Unity.PerformanceAnalysis
        protected virtual void MoveAiming()
        {
            playerCtrl.PlayerActionCtrl.FaceTarget(isAiming);
            //playerCtrl.PlayerActionCtrl.UpdateRigAndLayer(isAiming);
        }
    }

