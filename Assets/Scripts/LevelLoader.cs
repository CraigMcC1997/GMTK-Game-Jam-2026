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

    public void LoadTitle()
    {
        StartCoroutine(LoadScene("Scenes/TitleScene"));
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
