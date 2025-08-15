using UnityEngine;
using UnityEngine.UI;

public abstract class ButtonAbstract : MyMonoBehaviour
{
    [SerializeField]protected Button button;
    [SerializeField] protected SoundName soundNameClick = SoundName.ClickPunch;
    [SerializeField] protected bool playSfxOnClick = true;
    protected override void Start()
    {
        base.Start();
        this.AddOnClickEvent();
    }

    public virtual void AddOnClickEvent()
    {
        button.onClick.AddListener(HandleClick);

    }

    protected virtual void HandleClick()
    {
        OnClick();
        OnSfxClick();
    }
    public abstract void OnClick();

    protected virtual void OnSfxClick()
    {
        if (!playSfxOnClick == false && soundNameClick == SoundName.NoName) return;
        SoundManager.Instance.PlaySfx(soundNameClick);
    }
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
