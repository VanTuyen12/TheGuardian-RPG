using System;
using UnityEngine;
using UnityEngine.UI;

public abstract class SliderHp : SliderAbstract
{
    private void FixedUpdate()
    {
        this.UpdateSlider();
    }

    protected virtual void UpdateSlider()
    {
        this.slider.value = SetValue();
    }

    protected abstract float SetValue();

}
