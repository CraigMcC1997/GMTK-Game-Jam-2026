using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreenManager : MonoBehaviour
{

    public AudioClip clickAUDIO;
    AudioSource audioSource;
    public LevelLoader levelLoader;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void StartGame()
    {
        audioSource.PlayOneShot(clickAUDIO);
        levelLoader.ResetAll();
        levelLoader.LoadGame();
    }

    public void LoadControls()
    {
        audioSource.PlayOneShot(clickAUDIO);
        levelLoader.LoadControls();
    }

    public void ExitGame()
    {
        audioSource.PlayOneShot(clickAUDIO);
        Application.Quit();
    }
}
