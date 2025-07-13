using System;
using UnityEngine;

public class TextPlayerLevelUI : TextAbstract
{
    protected virtual void FixedUpdate()
    {
        this.LoadLevelPlayer();
    }

    protected virtual void LoadLevelPlayer()
    {
        txtProUi.text = PlayerCtrl.Instance.Level.CurrentLevel.ToString();
    }
}
