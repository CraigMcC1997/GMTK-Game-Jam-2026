using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreenManager : MonoBehaviour
{
    public LevelLoader levelLoader;
    public void StartGame()
    {
       levelLoader.LoadGame();
    }

    public void LoadControls()
    {
        levelLoader.LoadControls();
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
