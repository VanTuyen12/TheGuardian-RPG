using UnityEngine;
using UnityEngine.SceneManagement;

public class Btn_NewGame : ButtonAbstract
{
    
    public override void OnClick()
    {
        SceneManager.LoadScene("_Scenes/Game");
    }
    
}
