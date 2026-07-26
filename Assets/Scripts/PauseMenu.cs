using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;
    public LevelLoader levelLoader;

    public AudioClip clickAUDIO;
    AudioSource audioSource;


    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        pauseMenuUI.SetActive(false);
    }

    void Update()
    {
        if (Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            if (Time.timeScale == 0)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Pause()
    {
        audioSource.PlayOneShot(clickAUDIO);
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0;
    }

    public void Resume()
    {
        audioSource.PlayOneShot(clickAUDIO);
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
    }

    public void LoadUpgradesScreen()
    {
        Resume();
        levelLoader.LoadUpgrades();
    }

    public void ExitGame()
    {
        Resume();
        levelLoader.LoadTitle();
    }
}
