using System;
using UnityEngine;
using UnityEngine.Serialization;

public class BtnBuyTowerS : BtnAbsTowerUpgardeUI
{
    
    protected override TowerCodeName TowerName()
    {
        return TowerCodeName.MachineGunLv2;
    }
    public override void OnClick()
    {
        ComeBuyTower(TowerName());
    }
    
}
