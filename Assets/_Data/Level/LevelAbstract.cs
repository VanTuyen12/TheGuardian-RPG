using System;
using UnityEngine;

public abstract class LevelAbstract : MyMonoBehaviour
{
    [SerializeField] protected int currentLevel = 1;
    public int CurrentLevel => currentLevel;
    [SerializeField] protected int skillScore = 1;
    public int SkillScore => skillScore;
    [SerializeField] protected int maxLevel = 100;
    [SerializeField] protected int nextLevelExp;

    protected abstract int GetCurrentExp();
    protected abstract bool DeductExp(int exp);

    protected void FixedUpdate()
    {
        this.Leveling();
    }
   
    public virtual void UpgradeDamage(int amount)
    {
        if (skillScore < 0) return;
            skillScore -= amount;
    }

    protected virtual void Leveling()
    {
        if (this.currentLevel > maxLevel) return;
        if (this.GetCurrentExp() < GetNextLevelExp()) return;
        if (!DeductExp(GetNextLevelExp())) return;
        
        currentLevel++;
        skillScore++;
    }

    protected virtual int GetNextLevelExp()
    {
        return this.nextLevelExp = currentLevel * 10;
    }
}