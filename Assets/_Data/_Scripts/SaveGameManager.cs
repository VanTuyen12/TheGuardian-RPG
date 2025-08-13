using System;
using UnityEngine;

public class SaveGameManager : Singleton<SaveGameManager>
{
    private const int DEFAULT_GOLD = 5000;
    private const int DEFAULT_BULLET1 = 120;
    private const int DEFAULT_BULLET2 = 50;
    
    [SerializeField]private SaveData saveData;
    private int goldData = DEFAULT_GOLD;
    public int GoldData => goldData;
    
    private int bullet1 = DEFAULT_BULLET1;
    public int Bullet1Data => bullet1;
    
    private int bullet2 = DEFAULT_BULLET2;
    public int Bullet2Data => bullet2;

    protected override void Start()
    {
        base.Start();
        LoadData();
    }
    
    public virtual void LoadData()
    {
        saveData = LoadSystem.LoadGameData();
        if (saveData == null)
        {
            ResetToDefault();
            return;
        }
        
        goldData = saveData.currencyData.gold;
        bullet1 = saveData.bulletData.bullet_1;
        bullet2 = saveData.bulletData.bullet_2;
        
        Debug.Log(goldData);
    }

    public void NewGame()
    {
        ResetToDefault();
        SaveGame();
    }
    protected virtual void ResetToDefault()
    {
        goldData = DEFAULT_GOLD;
        bullet1 = DEFAULT_BULLET1;
        bullet2 = DEFAULT_BULLET2;
    }
    public void OnApplicationPause(bool pauseStatus)
    {
        if (pauseStatus)
        {
            SaveGame();
        }
    }

    public void OnApplicationQuit()
    {
        SaveGame();
    }

    public virtual void SaveGame()
    {
        SaveSystem.SaveGameState();
    }
}
