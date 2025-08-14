using UnityEngine;

public class SliderVolumSfx : SliderAbstract
{
    /*protected override void Start()
    {
        base.Start();
        if (SoundManager.Instance != null)
            this.slider.value = SoundManager.Instance.VolumeSfx;
    }*/
    protected override void OnSliderValueChanged(float value)
    {
        SoundManager.Instance.VolumeSfxUpdating(value);
    }
}
