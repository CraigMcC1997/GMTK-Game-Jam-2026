using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreenManager : MonoBehaviour
{
    public LevelLoader levelLoader;
    public void StartGame()
    {
       levelLoader.LoadGame();
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
