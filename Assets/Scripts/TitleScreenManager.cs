using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreenManager : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("Scenes/Prototype Level");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
