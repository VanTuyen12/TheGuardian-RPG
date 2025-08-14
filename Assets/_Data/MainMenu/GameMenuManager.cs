using System;
using SlimUI.ModernMenu;
using UnityEngine;

public class GameMenuManager : Singleton<GameMenuManager>
{ 
   
    public enum Theme {custom1, custom2, custom3};
    [Header("Theme")]
    public Theme theme;
    public ThemedUIData themeController;
    
    [Header("Menu Game")]
    [SerializeField] protected PlayGameCtrl playGameCtrl;
    public PlayGameCtrl PlayGameCtrl => playGameCtrl;
    
    [SerializeField] protected ExitCtrl exitCtrl;
    public ExitCtrl ExitCtrl => exitCtrl;
    
    [SerializeField] protected MainMenuCtrl mainMenuCtrl;
    public MainMenuCtrl MainMenuCtrl => mainMenuCtrl;
    
    [SerializeField] protected SettingCtrl settingCtrl;
    public SettingCtrl SettingCtrl => settingCtrl;
    
    [SerializeField] protected Animator animator;
    public Animator Animator => animator;
    protected override void Start()
    {
        base.Start();
        SetThemeColors();
    }
    
    public void PlayCampaign(){
        exitCtrl.Hide();
    }
    
    public void PlayExit(){
        playGameCtrl.Hide();
    }

    public void PlaySetings()
    {
        playGameCtrl.Hide();
        exitCtrl.Hide();
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadPlayGameCtrl();
        this.LoadExitCtrl();
        this.LoadMainMenuCtrl();
        this.LoadAnimatorCtrl();
        this.LoadSettingsCtrl();
    }
    
    protected virtual void LoadSettingsCtrl()
    {
        if(settingCtrl != null) return;
        settingCtrl = transform.GetComponentInChildren<SettingCtrl>();
        Debug.Log(transform.name + " :LoadSettingsCtrl",gameObject);
    }
    protected virtual void LoadAnimatorCtrl()
    {
        if(animator != null) return;
        animator = transform.GetComponent<Animator>();
        Debug.Log(transform.name + " :LoadAnimatorCtrl",gameObject);
    }
    protected virtual void LoadPlayGameCtrl()
    {
        if(playGameCtrl != null) return;
        playGameCtrl = transform.GetComponentInChildren<PlayGameCtrl>();
        Debug.Log(transform.name + " :LoadPlayGameCtrl",gameObject);
    }
    protected virtual void LoadExitCtrl()
    {
        if(exitCtrl != null) return;
        exitCtrl = transform.GetComponentInChildren<ExitCtrl>();
        Debug.Log(transform.name + " :LoadPlayGameCtrl",gameObject);
    }
    protected virtual void LoadMainMenuCtrl()
    {
        if(mainMenuCtrl != null) return;
        mainMenuCtrl = transform.GetComponentInChildren<MainMenuCtrl>();
        Debug.Log(transform.name + " :LoadPlayGameCtrl",gameObject);
    }
    protected virtual void SetThemeColors()
    {
        
        switch (theme)
        {
            case Theme.custom1:
                    themeController.currentColor = themeController.custom1.graphic1;
                    themeController.textColor = themeController.custom1.text1;
                    break;
            case Theme.custom2:
                    themeController.currentColor = themeController.custom2.graphic2;
                    themeController.textColor = themeController.custom2.text2;
                    break;
            case Theme.custom3:
                    themeController.currentColor = themeController.custom3.graphic3;
                    themeController.textColor = themeController.custom3.text3;
                    break;
            default:
                    Debug.Log("Invalid theme selected.");
                    break;
        }
    }
    
}
