using UnityEngine;

public class BtnsStatusToggle : ButtonAbstract
{
    public override void OnClick()
    {
        GameStatusUI.Instance.Toggle();
    }
}
