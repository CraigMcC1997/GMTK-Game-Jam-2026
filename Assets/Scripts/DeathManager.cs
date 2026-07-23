using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.SceneManagement;

public class DeathManager : MonoBehaviour
{
    public TMP_Text text;
    public int runTime = 3;
    
    public FollowMouse player; // Reference to the FollowMouse script
    public GameObject TimerUI;
    public AnimationCurve popCurve;
 
    void Start()
    {
        player.SetFollowingMouse(false); // Disable mouse following when the timer starts
        TimerUI.SetActive(true);
        StartCoroutine(ShowCountdown());
    }

    public IEnumerator ShowCountdown()
    {
        for (int i = runTime; i > 0; i--)
        {
            text.text = "YOU DIED!";
            yield return StartCoroutine(PopText());
        }

        TimerUI.SetActive(false);
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
