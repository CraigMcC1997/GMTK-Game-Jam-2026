using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.SceneManagement;

public class TimesUpManager : MonoBehaviour
{
    public TMP_Text text;
    public int runTime = 3;
    
    public FollowMouse player; // Reference to the FollowMouse script
    public GameObject pauseMenuUI;
    public GameObject IntroTimerUI;
    public AnimationCurve popCurve;
 
    void Start()
    {
        player.SetFollowingMouse(false); // Disable mouse following when the timer starts
        IntroTimerUI.SetActive(true);
        pauseMenuUI.SetActive(false);
        StartCoroutine(ShowCountdown());
    }

    public IEnumerator ShowCountdown()
    {
        for (int i = runTime; i > 0; i--)
        {
            text.text = "TIME'S UP!";
            yield return StartCoroutine(PopText());
        }

        IntroTimerUI.SetActive(false);
        SceneManager.LoadScene("Scenes/Upgrades Window");
    }

    IEnumerator PopText()
    {
        float duration = 0.8f;
        float elapsed = 0f;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;

            float t = elapsed / duration;

            float scale = popCurve.Evaluate(t);

            text.transform.localScale = Vector3.one * scale;

            yield return null;
        }

        text.transform.localScale = Vector3.one;
    }
}
