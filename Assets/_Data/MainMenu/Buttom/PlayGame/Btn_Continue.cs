using UnityEngine;
using UnityEngine.SceneManagement;

public class Btn_Continue : ButtonAbstract
{
    public override void OnClick()
    {
        SaveGameManager.Instance.LoadData();
        SceneManager.LoadScene("_Scenes/Game");
    }
}
