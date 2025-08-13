using UnityEngine;
using UnityEngine.SceneManagement;

public class Btn_NewGame : ButtonAbstract
{
    
    public override void OnClick()
    {
        SaveGameManager.Instance.NewGame();
        SceneManager.LoadScene("_Scenes/Game");
    }
    
}
