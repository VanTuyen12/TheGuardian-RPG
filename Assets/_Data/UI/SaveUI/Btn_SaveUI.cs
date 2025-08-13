using UnityEngine;

public class Btn_SaveUI : ButtonAbstract
{
    public override void OnClick()
    {
        SaveGameManager.Instance.SaveGame();
    }
    
}
