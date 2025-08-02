using UnityEngine;

public class BtnToggleMusic : ButtonAbstract
{
    public override void OnClick()
    {
        SoundManager.Instance.ToggleMusic();
    }
}
