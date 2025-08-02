using UnityEngine;

public abstract class MusicCtrl : SoundCtrl
{
    protected override void ResetValue()
    {
        base.ResetValue();
        audioSource.loop = true;
    }
}
