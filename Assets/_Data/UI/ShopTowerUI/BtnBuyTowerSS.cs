using System;
using UnityEngine;
using UnityEngine.Serialization;

public class BtnBuyTowerSS : BtnAbsTowerUpgardeUI
{
    
    protected override TowerCodeName TowerName()
    {
        return TowerCodeName.MachineGunLv3;
    }
    public override void OnClick()
    {
        ComeBuyTower(TowerName());
    }
    
}
