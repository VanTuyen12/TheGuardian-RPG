using System.Collections.Generic;
using UnityEngine;

public class EnemyPrefabs : EnemyManagerAbstract
{
    [SerializeField] protected List<EnemyCtrl> prefabs;

    protected override void Awake()
    {
        base.Awake();
        this.HidePrefabs();
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadEnemyCtrl();
    }

    protected virtual void LoadEnemyCtrl()
    {
        if(prefabs.Count > 0) return;
        foreach (Transform child in transform)
        {
            EnemyCtrl enemyCtrl = child.GetComponent<EnemyCtrl>();
            if (enemyCtrl) this.prefabs.Add(enemyCtrl);
        }
        Debug.Log(transform.name + " :LoadEnemyCtrl",gameObject);
       
    }

    protected virtual void HidePrefabs()
    {
        foreach (var prefab in prefabs)
        {
            prefab.gameObject.SetActive(false);
        }
    } 
    public virtual EnemyCtrl GetRandomPrefab()
    {
        int rand =  Random.Range(0, prefabs.Count);
        
        return prefabs[rand];
    }
}
