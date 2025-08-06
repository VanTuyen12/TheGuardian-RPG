using System;
using System.Collections.Generic;
using UnityEngine;

public class TowerStandUIManager : MyMonoBehaviour
{
    [SerializeField] protected TowerStandCtrl towerStand;
    [SerializeField] protected List<TextTowerStandUI> skillScoreTexts = new();

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadtowerStand();
        this.LoadTextSkillScoreUI();
    }
    
    
    protected virtual void SetupTextReferences()
    {
        /*foreach (var textUI in skillScoreTexts)
        {
            textUI.SetTowerStand(towerStand);
        }*/
    }
    
    public virtual void OnTowerSpawned(TowerCtrl tower)
    {
        
    }
    
    public virtual void OnTowerDespawned()
    {
        
    }
    protected virtual void LoadTextSkillScoreUI()
    {
        if (skillScoreTexts.Count > 0) return;
        skillScoreTexts = new List<TextTowerStandUI>(
            FindObjectsByType<TextTowerStandUI>(FindObjectsSortMode.None)
        );
    }
    
    protected virtual void LoadtowerStand()
    {
        if (towerStand!= null) return;
        towerStand = GetComponent<TowerStandCtrl>();
        Debug.Log(transform.name + " :LoadtowerStand ",gameObject);
    }
}
