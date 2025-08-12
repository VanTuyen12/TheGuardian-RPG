using UnityEngine;

public class ExitCtrl : ToggleAbstractUI<ExitCtrl>
{
    [SerializeField]protected Btn_No btnNo;
    public Btn_No BtnNo => btnNo;
    [SerializeField]protected Btn_Yes btnYes;
    public Btn_Yes BtnYes => btnYes;
    protected override void HotkeyToogleUI(){}

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LodaBtn_No();
        LodaBtn_Yes();
    }
    
    protected virtual void LodaBtn_Yes()
    {
        if(btnYes != null) return;
        btnYes = GetComponentInChildren<Btn_Yes>();
        Debug.Log(transform.name + " :LodaBtn_Yes",gameObject);
    }
    protected virtual void LodaBtn_No()
    {
        if(btnNo != null) return;
        btnNo = GetComponentInChildren<Btn_No>();
        Debug.Log(transform.name + " :LodaBtn_No",gameObject);
    }
}
