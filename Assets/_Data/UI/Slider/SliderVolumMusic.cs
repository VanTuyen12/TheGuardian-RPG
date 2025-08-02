using UnityEngine;

public class SliderVolumMusic : SliderAbstract
{
    protected override void OnSliderValueChanged(float value)
    {
        SoundManager.Instance.VolumeMusicUpdating(value);
    }
}
