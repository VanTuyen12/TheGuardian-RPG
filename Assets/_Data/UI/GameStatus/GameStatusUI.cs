using System;
using UnityEngine;

public class GameStatusUI : Singleton<GameStatusUI>
{
    [SerializeField] protected Transform objLoseGame;
    [SerializeField] private bool isLose = false;
    public bool IsLose => isLose;
    
    protected override void Start()
    {
        base.Start();
        objLoseGame.gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        GameEvent.OnEnemyReachEnd += GameEventOnOnEnemyReachEnd;
    }
    private void GameEventOnOnEnemyReachEnd(bool obj)
    {
        isLose = obj;
        LoseGame(isLose);
    }

    public virtual void LoseGame(bool lose)
    {
        objLoseGame.gameObject.SetActive(lose);
        Time.timeScale = 0f;
    }
    private void OnDisable()
    {
        GameEvent.OnEnemyReachEnd -= GameEventOnOnEnemyReachEnd;
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadObjLoseGame();

    }

    protected virtual void LoadObjLoseGame()
    {
        if (this.objLoseGame != null) return;
        this.objLoseGame = transform.Find("LoseGame");
        Debug.Log(transform.name + " :LoadObjLoseGame " ,gameObject);
        
    }
}
