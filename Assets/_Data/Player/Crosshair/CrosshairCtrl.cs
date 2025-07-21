using System.Collections.Generic;
using UnityEngine;

public class CrosshairCtrl : Singleton<CrosshairCtrl>
{
    [SerializeField]List<CrosshairAbstract> crosshairs = new();

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadCrosshair();
    }
    
    protected virtual void LoadCrosshair()
    {
        if (crosshairs.Count > 0) return;
        foreach (Transform child  in transform)
        {
            CrosshairAbstract crosshairAbstract = child.GetComponentInChildren<CrosshairAbstract>();
            if (crosshairAbstract == null) continue;
            this.crosshairs.Add(crosshairAbstract);
        }
        Debug.Log(transform.name + "LoadCrosshair",gameObject);
    }

    public virtual CrosshairAbstract GetCrosshair(int crosshairIndex)
    {
        return crosshairs[crosshairIndex];
    }
}
