using UnityEngine;
using UnityEngine.SceneManagement;

public class BtnNewGame : ButtonAbstract
{
    
    public override void OnClick()
    {
        SceneManager.LoadScene("_Scenes/Game");
    }
    
}
