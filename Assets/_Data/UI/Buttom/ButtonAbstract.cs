using UnityEngine;
using UnityEngine.UI;

public abstract class ButtonAbstract : PoolObj
{
    [SerializeField]protected Button button;
    protected override void Start()
    {
        base.Start();
        this.AddOnClickEvent();
    }

    public virtual void AddOnClickEvent()
    {
        button.onClick.AddListener(OnClick);
    }

    public abstract void OnClick();
    
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadButton();
    }

    protected virtual void LoadButton()
    {
        if (this.button != null) return;
        button = GetComponent<Button>();
        Debug.Log(transform.name + " :LoadButton " , gameObject);
    }
}
