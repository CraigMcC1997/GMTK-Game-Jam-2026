using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LevelLoader : MonoBehaviour
{
    public Animator transition;
    public const float transitionTime = 0.75f;

    public void LoadGame()
    {
        StartCoroutine(LoadScene("Scenes/Prototype Level"));
    }

    public void LoadUpgrades()
    {
        StartCoroutine(LoadScene("Scenes/Upgrades Window"));
    }

    public void ResetAll()
    {
        PlayerPrefs.SetInt("HealthSlotsUsed", 0);
        PlayerPrefs.SetInt("SpeedSlotsUsed", 0); 
        PlayerPrefs.SetInt("ShieldSlotsUsed", 0);
        PlayerPrefs.SetInt("numShields", 0);
        PlayerPrefs.SetInt("BombTimeSlotsUsed", 0);
        PlayerPrefs.SetInt("BombRangeSlotsUsed", 0);
        PlayerPrefs.SetInt("CoinCount", 0);
        PlayerPrefs.SetInt("numBombs", 0);
        PlayerPrefs.SetInt("KeyCount", 0);
        PlayerPrefs.SetInt("Attempts", 0);
        PlayerPrefs.SetInt("ShieldButtonClicked", 0);
        PlayerPrefs.SetInt("BombButtonClicked", 0);
    }

    public void PlayAgain()
    {
        ResetAll();
        LoadTitle();
    }

    public void LoadTitle()
    {
        StartCoroutine(LoadScene("Scenes/TitleScene"));
    }

    public void LoadControls()
    {
        StartCoroutine(LoadScene("Scenes/Controls Page"));
    }

    public void LoadWinScene()
    {
        StartCoroutine(LoadScene("Scenes/Win Scene"));
    }

    IEnumerator LoadScene(string sceneName)
    {
        if (transition != null)
        {
            transition.SetTrigger("Start");
            yield return new WaitForSeconds(transitionTime);
        }
        SceneManager.LoadScene(sceneName);
    }
}
