using UnityEngine;

public class TextTowerUpgradeUI : TextTowerStandUI
{
    protected override void DoShowUpgrade()
    {
        if (currentTower == null) return;
        
        int skillScore = currentTower.Level.SkillScore;
        txtProUi.text = $"Skill Score: {skillScore}";
    }
}
