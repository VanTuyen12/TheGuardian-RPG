using UnityEngine;

public abstract class TextSkillScoreUI : TextAbstract
{
    [SerializeField] protected TowerStandCtrl towerStand; 
    protected abstract TowerCodeName SetTargetTowerType();
    protected virtual void FixedUpdate()
    {
        this.LoadSkillScore();
    }

    protected virtual void LoadSkillScore()
    {
        towerStand = TowerUpgardeUI.Instance.StandCtrl;
        if (towerStand == null)
        {
            txtProUi.text = $"Skill Score: 0";
            return;
        }
        
        if (towerStand.TowerPrefab != null && 
            IsMatchingTowerType(towerStand.TowerPrefab) &&
            towerStand.IsTowerBought(SetTargetTowerType()))
        {
            int skillScore = towerStand.SetSkillScore(towerStand.TowerPrefab);
            txtProUi.text = $"Skill Score: {skillScore}";
        }
        else
        {
            txtProUi.text = $"Skill Score: 0";
        }
    }
    
    protected virtual bool IsMatchingTowerType(TowerCtrl tower)
    {
        string towerTypeName = tower.GetName();
        string targetTypeName = SetTargetTowerType().ToString();
        
        return towerTypeName.Equals(targetTypeName);
    }
    
}
