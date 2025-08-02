using UnityEngine;
using UnityEngine.UI;

public abstract class SliderAbstract : MyMonoBehaviour
{
    [SerializeField]protected Slider slider;
    protected override void Start()
    {
        base.Start();
        this.slider.onValueChanged.AddListener(this.OnSliderValueChanged);
    }

    protected virtual void OnSliderValueChanged(float value)
    {
        //For Override
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSlider();
    }

    protected virtual void LoadSlider()
    {
        if (this.slider != null) return;
        this.slider = GetComponent<Slider>();
        Debug.Log(transform.name + " :LoadSlider",gameObject);
    }
}
