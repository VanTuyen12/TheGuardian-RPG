using System;
using UnityEngine;

public class GameStatusUI : GameplayToggleUI<GameStatusUI>
{
    [SerializeField] protected Transform gameOverUI;
    [SerializeField] private bool isLose = false;
    public bool IsLose => isLose;
    
    protected override void Start()
    {
        base.Start();
        gameOverUI.gameObject.SetActive(false);
    }

    protected override void HotkeyToogleUI()
    {
        if(InputHotKeys.Instance.IsTooleStatusUI) Toggle();
    }

    private void OnEnable()
    {
        GameEvent.OnEnemyReachEnd += GameEventOnOnEnemyReachEnd;
    }
    private void GameEventOnOnEnemyReachEnd(bool obj)
    {
        isLose = obj;
        GameOver(isLose);
    }

    public virtual void GameOver(bool lose)
    {
        gameOverUI.gameObject.SetActive(lose);
        SettingsUIManager.Instance.Show();
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
        if (this.gameOverUI != null) return;
        this.gameOverUI = transform.Find("GameOverUI");
        Debug.Log(transform.name + " :LoadObjLoseGame " ,gameObject);
        
    }
}
