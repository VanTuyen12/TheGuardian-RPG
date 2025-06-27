using System;
using UnityEngine;

public class PlayerShoot : AttackAbstract
{
    
    protected override void Shooting()
    {
        if (playerCtrl.StarterAssetsInputs.shoot)
        {
            AttackPoint attackPoint = GetAttackPoint();
            Debug.Log("Shootingggg" + attackPoint.transform.position);
            playerCtrl.StarterAssetsInputs.shoot = false; 
        }
        
    }
}
