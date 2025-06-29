using System.Collections.Generic;
using UnityEngine;

public class CrosshairCtrl : MyMonoBehaviour
{
    [SerializeField]List<CrosshairAbstract> crosshairs = new();
    public List<CrosshairAbstract> Crosshairs => crosshairs;

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
