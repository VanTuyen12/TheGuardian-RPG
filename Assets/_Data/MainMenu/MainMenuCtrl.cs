using UnityEngine;

public class MainMenuCtrl : MyMonoBehaviour
{
    [SerializeField]Btn_PlayCampaign _playCampaign;
    public Btn_PlayCampaign Btn_PlayCampaign => _playCampaign;
    
    [SerializeField]Btn_Settings _playSettings;
    public Btn_Settings Btn_Settings => _playSettings;
    
    [SerializeField]Btn_Exit _playExit;
    public Btn_Exit Btn_Exit => _playExit;
    
    [SerializeField] Animator _animator;
    public Animator Animator => _animator;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadBtn_PlayCampaign();
        this.LoadBtn_PlaySettings();
        this.LoadBtn_PlayExitOptions();
        this.LoadAnimator();

    }

    public void ShowSettings()
    {
        
    }
    protected virtual void LoadAnimator()
    {
        if(_animator != null) return;
        _animator = GetComponent<Animator>();
        Debug.Log(transform.name + " :LoadAnimator",gameObject);
    }
    protected virtual void LoadBtn_PlayCampaign()
    {
        if(_playCampaign != null) return;
        _playCampaign = GetComponentInChildren<Btn_PlayCampaign>();
        Debug.Log(transform.name + " :LodaBtn_PlayCampaign",gameObject);
    }
    protected virtual void LoadBtn_PlaySettings()
    {
        if(_playSettings != null) return;
        _playSettings = GetComponentInChildren<Btn_Settings>();
        Debug.Log(transform.name + " :LoadBtn_PlaySettings",gameObject);
    }
    protected virtual void LoadBtn_PlayExitOptions()
    {
        if(_playExit != null) return;
        _playExit = GetComponentInChildren<Btn_Exit>();
        Debug.Log(transform.name + " :LoadBtn_PlayExitOptions",gameObject);
    }
}
