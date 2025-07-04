using UnityEngine;

public class InventoryUI : Singleton<InventoryUI>
{
    [SerializeField]private bool isShow = false;
    public bool IsShow => isShow;

    protected override void Start()
    {
        base.Start();
        //Hide();
        Show();
    }

    public virtual void Show()
    {
        isShow = true;
        gameObject.SetActive(isShow);
    }

    public virtual void Hide()
    {
        isShow = false;
        gameObject.SetActive(isShow);
    }

    public virtual void Toggle()
    {
        if (isShow) Hide();
        else Show();
        
    }
}
