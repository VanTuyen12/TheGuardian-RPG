using System.Collections.Generic;
using UnityEngine;

public class PlayerSkillsCtrl : MyMonoBehaviour
{
    [SerializeField]List<SkillsGunAbstract>  skills;
    public List<SkillsGunAbstract> Skills => skills;

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
            SkillsGunAbstract skillGunPrefabs =  child.GetComponent<SkillsGunAbstract>();
            if (skillGunPrefabs != null) skills.Add(skillGunPrefabs);
        }
        //Debug.Log(transform.name + " :LoadSkills ",gameObject);
    }
}
