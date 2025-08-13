using UnityEngine;

public class SliderVolumMusic : SliderAbstract
{
    protected override void Start()
    {
        base.Start();
        if (SoundManager.Instance != null)
            this.slider.value = SoundManager.Instance.VolumeMusic;
    }
    protected override void OnSliderValueChanged(float value)
    {
        SoundManager.Instance.VolumeMusicUpdating(value);
    }
}
