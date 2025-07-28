using UnityEngine;

public class TextSkillScoreUI : TextAbstract
{
    protected virtual void FixedUpdate()
    {
        this.LoadSkillScore();
    }

    protected virtual void LoadSkillScore()
    {
        TowerStandCtrl towerStand = TowerUpgardeUI.Instance.BtnTowerUpgardeUI.TowerStand;
        var tower = towerStand.TowerPrefab;
        
        int skillScore;
        skillScore = tower == null ? 0 : towerStand.SetSkillScore(tower);
        
        txtProUi.text = $"Skill Score: {skillScore}";
    }
}
