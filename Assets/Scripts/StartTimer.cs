using UnityEngine;
using TMPro;
using System.Collections;


public class StartTimer : MonoBehaviour
{
    public TMP_Text timerText;
    public int remainingTime = 3;
    bool IntroTimerFinished = false;
    
    public GameObject IntroTimerUI;
    public AnimationCurve popCurve;

    public FollowMouse player; // Reference to the FollowMouse script

    public bool GetIntroTimerFinished()
    {
        return IntroTimerFinished || !IntroTimerUI.activeSelf;
    }
 
    void Start()
    {
        IntroTimerUI.SetActive(true);
        StartCoroutine(ShowCountdown());

        if (player != null)
        {
            player.SetFollowingMouse(false);
        }
    }

    public IEnumerator ShowCountdown()
    {
        for (int i = 3; i > 0; i--)
        {
            timerText.text = i.ToString();
            yield return StartCoroutine(PopText());
        }

        timerText.text = "GO!";
        yield return StartCoroutine(PopText());
        IntroTimerFinished = true;
        IntroTimerUI.SetActive(false);
        if (player != null)
        {
            player.SetFollowingMouse(true); // Enable mouse following after the countdown
        }
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

            timerText.transform.localScale = Vector3.one * scale;

            yield return null;
        }

        timerText.transform.localScale = Vector3.one;
    }
}
