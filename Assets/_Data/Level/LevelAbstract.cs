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
    
    [SerializeField] protected int baseExp = 5;

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
        LevelingUp();
        skillScore++;
    }

    protected virtual void LevelingUp()
    {
        //For override
    }
    protected virtual int GetNextLevelExp()
    {
        return this.nextLevelExp = baseExp * currentLevel * currentLevel;
    }
    
    public virtual void SetSkillScore(int rsScore)
    {
        skillScore = rsScore;
    }
    public virtual void SetCurrentLevel(int rsLevel)
    {
        currentLevel = rsLevel;
    }
}