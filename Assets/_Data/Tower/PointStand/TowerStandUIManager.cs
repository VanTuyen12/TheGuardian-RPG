using System;
using System.Collections.Generic;
using UnityEngine;

public class TowerStandUIManager : MyMonoBehaviour
{
    [SerializeField] protected TowerStandCtrl towerStand;
    [SerializeField] protected List<TextSkillScoreUI> skillScoreTexts;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadtowerStand();
    }
    
    protected override void Start()
    {
        base.Start();
        LoadSkillScores();
        //this.SetupTextReferences();
    }

    protected virtual void LoadSkillScores()
    {
        if (skillScoreTexts == null || skillScoreTexts.Count == 0)
            skillScoreTexts = new List<TextSkillScoreUI>(FindObjectsOfType<TextSkillScoreUI>());
    }
    
    protected virtual void SetupTextReferences()
    {
        // Set reference cho tất cả text UI về tower stand này
        /*foreach (var textUI in skillScoreTexts)
        {
            textUI.SetTowerStand(towerStand);
        }*/
    }
    
    // Method được gọi khi tower được spawn
    public virtual void OnTowerSpawned(TowerCtrl tower)
    {
        // Không cần làm gì thêm, TextSkillScoreUI sẽ tự động update
    }
    
    // Method được gọi khi tower bị despawn
    public virtual void OnTowerDespawned()
    {
        // TextSkillScoreUI sẽ tự động hiển thị 0 khi không có tower
    }
    
    protected virtual void LoadtowerStand()
    {
        if (towerStand!= null) return;
        towerStand = GetComponent<TowerStandCtrl>();
        Debug.Log(transform.name + " :LoadtowerStand ",gameObject);
    }
}
