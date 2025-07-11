using UnityEngine;

public class TowerLevel : LevelAbstract
{
    [SerializeField] protected TowerCtrl towerCtrl;
    
    protected override int GetCurrentExp()
    {
        return towerCtrl.TowerShooting.KillCount;
    }

    protected override bool DeductExp(int exp)
    {
        return towerCtrl.TowerShooting.DeductKillCount(exp);
    }

    protected override int GetNextLevelExp()
    {
        return nextLevelExp = currentLevel * 2;
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadTowerCtrl();
    }

    protected virtual void LoadTowerCtrl()
    {
        if(this.towerCtrl != null) return;
        towerCtrl = GetComponentInParent<TowerCtrl>();
        Debug.Log(transform.name + " :LoadTowerCtrl",gameObject);
    }
}
