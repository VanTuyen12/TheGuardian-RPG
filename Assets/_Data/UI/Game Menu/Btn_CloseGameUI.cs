using UnityEngine;
using UnityEngine.SceneManagement;

public class Btn_CloseGameUI : ButtonAbstract
{
    
    public override void OnClick()
    {
        SceneManager.LoadScene("_Scenes/MainMenu");
    }
    
}
