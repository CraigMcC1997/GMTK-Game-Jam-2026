using UnityEngine;
using TMPro;
using System.Collections;


public class StartTimer : MonoBehaviour
{
    public TMP_Text timerText;
    public int remainingTime = 3;
    bool IntroTimerFinished = false;

    public bool GetIntroTimerFinished()
    {
        return IntroTimerFinished;
    }
 
    void Start()
    {
        gameObject.SetActive(true);
        //timerText.text = remainingTime.ToString();
        StartCoroutine(ShowCountdown());
    }

    // Update is called once per frame
    void Update()
    {
    //     // Game Over, early exit to avoid further updates
    //     if (IntroTimerFinished)
    //     {
    //         gameObject.SetActive(false);
    //     }
    //     else
    //     {
    //         // check for game over condition otherwise countdown the timer
    //         if (remainingTime <= 0)
    //         {
    //             remainingTime = 0;  // Ensure remainingTime doesn't go below 0
    //             IntroTimerFinished = true;
    //         }
    //         else
    //         {
    //             remainingTime -= 1;
    //             timerText.text = remainingTime.ToString();
    //         }
    //     }
    }

    public AnimationCurve popCurve;

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
        gameObject.SetActive(false);
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
