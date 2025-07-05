using UnityEngine;

public class InventoryUI : Singleton<InventoryUI>
{
    [SerializeField]protected BtnItemInventory itemInventory;
    [SerializeField]private bool isShow = false;
    public bool IsShow => isShow;

    protected override void Start()
    {
        base.Start();
        //Hide();
        Show();
        this.HideDefaultItemInventory();
    }

    

    protected virtual void HideDefaultItemInventory()
    {
        itemInventory.gameObject.SetActive(false);
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
    
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadBtnItemInventory();
    }

    protected virtual void LoadBtnItemInventory()
    {
        if (itemInventory != null) return;
        itemInventory = GetComponentInChildren<BtnItemInventory>();
        Debug.Log(transform.name + ": LoadBtnItemInventory", gameObject);
    }
}
