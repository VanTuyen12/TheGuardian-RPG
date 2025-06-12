using System;
using UnityEngine;

public class MyMonoBehaviour : MonoBehaviour
{
    protected virtual void Awake()
    {
        this.LoadComponents();
    }

    protected virtual void Start()
    {
        //For Override
    }
    protected virtual void Reset()
    {
        this.LoadComponents();
    }
    
    protected virtual void LoadComponents()
    {
        //For Override
    }
}
