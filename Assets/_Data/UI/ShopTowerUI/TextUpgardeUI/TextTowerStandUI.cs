using UnityEngine;
using UnityEngine.Serialization;

public abstract class TextTowerStandUI : TextAbstract
{
    [SerializeField] protected TowerCodeName targetTowerType;
    protected TowerStandCtrl currentTowerStand;
    protected TowerCtrl currentTower;
    protected abstract void DoShowUpgrade();
    protected override void Start()
    {
        base.Start();
        SetTextShow();
    }

    protected virtual void FixedUpdate()
    {
        this.LoadShowTowerText();
    }

    protected virtual void LoadShowTowerText()
    {
        currentTowerStand = TowerUIManager.Instance.StandCtrl;
        if (currentTowerStand == null) return;
        
        currentTower = currentTowerStand.TowerPrefab;
        if (!CanUseShow())
        {
            SetTextShow(); 
            return;
        }

        DoShowUpgrade();
    }
    protected virtual void SetTextShow()
    {
        if (txtProUi != null)
        {
            txtProUi.text = $"Skill Score: 0";
        }
    }
    protected virtual bool CanUseShow()
    {
        if (currentTower == null ) return false;
        if (!currentTowerStand.IsTowerBought(targetTowerType)) return false;
        if(!IsMatchingTowerType(currentTower)) return false;
        
        return true;
    }
    
    protected virtual bool IsMatchingTowerType(TowerCtrl tower)
    {
        string towerTypeName = tower.GetName();
        string targetTypeName =targetTowerType.ToString();
        
        return towerTypeName.Equals(targetTypeName);
    }
    public virtual void SetTargetTowerType(TowerCodeName towerType)
    {
        targetTowerType = towerType;
    }
}
