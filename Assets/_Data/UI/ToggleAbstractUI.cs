using System;
using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class ToggleAbstractUI<T> : Singleton<T> where T : MyMonoBehaviour
{
    
    [SerializeField] protected GameObject showHideUI;
   
    [SerializeField]protected bool isShow = false;
        
    public bool IsShow => isShow;

    protected override void Start()
    {
        base.Start();
        Hide();
        //Show();
    }
    

    private void LateUpdate()
    {
        this.HotkeyToogleInventory();
    }

    protected abstract void HotkeyToogleInventory();

    public virtual void Show()
    {
        isShow = true;
        showHideUI.gameObject.SetActive(isShow);
    }

    public virtual void Hide()
    {
        isShow = false;
        showHideUI.gameObject.SetActive(isShow);
    }

    public virtual void Toggle()
    {
        if (isShow) Hide();
        else Show();
        
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadShowHideUI();
    }
    protected virtual void LoadShowHideUI()
    {
        if (showHideUI != null) return;
        showHideUI = FindChildWithTag(transform,"ShowHideUI");
        Debug.Log(transform.name + ": loadShowHideUI", gameObject);
    }
    
    protected  virtual GameObject FindChildWithTag(Transform parent, string tag)
    {
        foreach (Transform child in parent)
        {
            if (child.CompareTag(tag))
                return child.gameObject;
        }
        return null;
    }
}
