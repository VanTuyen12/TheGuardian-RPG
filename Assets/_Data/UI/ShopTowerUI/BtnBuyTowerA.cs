using UnityEngine;

public class BtnBuyTowerA : BtnAbstractBuy
{
    public override void OnClick()
    {
        UpdateBuyTower();
    }

    protected virtual void UpdateBuyTower()
    {
        if (towerPrefab == null)
        {
            Vector3 prefabPos = TowerUpgardeUI.Instance.HandleTower.transform.GetComponent<GunStandCtrl>().Point.transform.position;//gunStand.Point.transform.position;
            towerPrefab = TowerSingleton.Instance.Prefabs.Spawn(GetTowerPrefabs(TowerCodeName.MachineGunLv1), prefabPos);//GetTowerPrefabs(TowerCodeName.MachineGunLv1);
            //towerPrefab.transform.position = prefabPos;
            towerPrefab.SetActive(true);
        }

        towerPrefab = null;
    }
}
