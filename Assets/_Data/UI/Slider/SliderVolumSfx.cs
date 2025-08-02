using UnityEngine;

public class SliderVolumSfx : SliderAbstract
{
    protected override void OnSliderValueChanged(float value)
    {
        SoundManager.Instance.VolumeSfxUpdating(value);
    }
}
