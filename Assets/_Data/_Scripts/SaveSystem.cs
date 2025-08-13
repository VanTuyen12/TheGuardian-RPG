using System;
using System.IO;
using System.Net;
using UnityEngine;

public static class SaveSystem 
{
    public const string FILENAME_SAVEDATA = "/savedata.json";

    public static void SaveGameState()
    {
        string filePathSaveData = Application.persistentDataPath + FILENAME_SAVEDATA;
        CurrencyData currencyData = new CurrencyData(InventoryManager.Instance.Currency());
        BulletData bulletData = new BulletData(InventoryManager.Instance.Items());
        SaveData saveData = new SaveData(currencyData,bulletData);
        string jsonSaveData = JsonUtility.ToJson(saveData);
        File.WriteAllText(filePathSaveData, jsonSaveData);
        
        //Debug.Log(filePathSaveData);
    }
}

[Serializable]
public class SaveData
{
    public CurrencyData currencyData;
    public BulletData bulletData;

    public SaveData(CurrencyData currencyData,BulletData bulletData)
    {
        this.currencyData = currencyData;
        this.bulletData = bulletData;
    }
    
    
}

[Serializable]
public class CurrencyData
{
    public int gold;
    public CurrencyData(InventoryCtrl inventoryCtrl)
    {
        gold = inventoryCtrl.FindItem(ItemCode.Gold).itemCount;
    }
}

[Serializable]
public class BulletData
{
    public int bullet_1;
    public int bullet_2;

    public BulletData(InventoryCtrl inventoryCtrl) 
    {
        bullet_1 =  inventoryCtrl.FindItem(ItemCode.Bullet1).itemCount;
        bullet_2 =  inventoryCtrl.FindItem(ItemCode.Bullet2).itemCount;
    }
}

