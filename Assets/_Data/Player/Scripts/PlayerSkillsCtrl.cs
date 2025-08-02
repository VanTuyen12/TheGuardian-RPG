using System.Collections.Generic;
using UnityEngine;

public class PlayerSkillsCtrl : MyMonoBehaviour
{
    [SerializeField]List<SkillsAbstract>  skills;
    public List<SkillsAbstract> Skills => skills;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSkills();
    }
    protected virtual void LoadSkills()
    {
        if(this.skills.Count > 0) return;
        foreach (Transform child in transform)
        {
            SkillsAbstract skillPrefabs =  child.GetComponent<SkillsAbstract>();
            if (skillPrefabs != null) skills.Add(skillPrefabs);
        }
        //Debug.Log(transform.name + " :LoadSkills ",gameObject);
    }
}
