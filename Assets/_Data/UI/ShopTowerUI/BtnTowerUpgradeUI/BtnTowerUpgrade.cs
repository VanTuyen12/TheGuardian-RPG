using UnityEngine;

public abstract class BtnTowerUpgrade : ButtonAbstract
{
    [SerializeField] protected TowerCodeName targetTowerType;
    protected TowerStandCtrl currentTowerStand;
    protected TowerCtrl currentTower;
    
    protected abstract void DoUpgrade();
    
    protected override void Start()
    {
        base.Start();
        SetBtnInteractable(false);
    }
    
    private void FixedUpdate()
    {
        CheckButtonState();
    }
    
    public override void OnClick()
    {
        if (button != null)
        {
            OnButtonClick();
        }
        
    }
    
    protected virtual void CheckButtonState()
    {
        currentTowerStand = TowerUIManager.Instance.StandCtrl;
        
        if (currentTowerStand == null)
        {
            SetBtnInteractable(false);
            return;
        }
        
        currentTower = currentTowerStand.TowerPrefab;
        
        bool canUseButton = CanUseButton();
        SetBtnInteractable(canUseButton);
    }
    
    protected virtual bool CanUseButton()
    {
        if (currentTower == null) return false;
        
        if (!currentTowerStand.IsTowerBought(targetTowerType)) return false;
        
        if (!IsSameTowerType(currentTower)) return false;
        
        if (currentTower.Level.SkillScore <= 0) return false;
        
        return true;
    }
    
    protected virtual bool IsSameTowerType(TowerCtrl tower)
    {
        string towerName = tower.GetName();
        string targetName = targetTowerType.ToString();
        return towerName.Equals(targetName);
    }
    
    protected virtual void SetBtnInteractable(bool interactable)
    {
        if (button != null)
        {
            button.interactable = interactable;
        }
    }
    
    protected virtual void OnButtonClick()
    {
        if (!CanUseButton()) return;
        
        DoUpgrade();
        currentTower.Level.UpgradeDamage(1);
    }
    public virtual void SetTargetTowerType(TowerCodeName towerType)
    {
        targetTowerType = towerType;
    }
}
