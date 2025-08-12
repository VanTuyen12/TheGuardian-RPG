using UnityEngine;

public abstract class GameplayToggleUI<T> : ToggleAbstractUI<T> where T :MyMonoBehaviour
{
    protected override void OnShowUI()
    {
        base.OnShowUI();
        MouseCursorManager.Instance.SetCursorVisible(true, GetType().Name);
    }

    protected override void OnHideUI()
    {
        base.OnHideUI();
        MouseCursorManager.Instance.SetCursorVisible(false, GetType().Name);
    }
}
