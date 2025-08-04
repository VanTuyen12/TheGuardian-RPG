using System;
using UnityEngine;

public class PointStand : MyMonoBehaviour
{
    [SerializeField]protected Transform model;
    public Transform Model  => model;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadModel();
    }

    protected virtual void LoadModel()
    {
        if(model != null) return;
        model = transform.Find("Model").gameObject.transform;
    }
}
