using System;
using UnityEngine;
using UnityEngine.Serialization;

public class BtnBuyTowerA : BtnAbsTowerUpgardeUI
{
    
    protected override TowerCodeName TowerName()
    {
        return TowerCodeName.MachineGunLv1;
    }
    public override void OnClick()
    {
        ComeBuyTower(TowerName());
    }
    
}
