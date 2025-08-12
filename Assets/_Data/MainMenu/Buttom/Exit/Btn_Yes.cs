using UnityEngine;

public class Btn_Yes : ButtonAbstract
{
    public override void OnClick()
    {
       Application.Quit();
    }
}
