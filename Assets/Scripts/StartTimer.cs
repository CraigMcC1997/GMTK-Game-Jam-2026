using UnityEngine;
using TMPro;
using Unity.VisualScripting;


public class StartTimer : MonoBehaviour
{
    public TMP_Text timerText;
    public float remainingTime = 30f;
    bool IntroTimerFinished = false;

    public bool GetIntroTimerFinished()
    {
        return IntroTimerFinished;
    }
 
    void Start()
    {
        gameObject.SetActive(true);
        timerText.text = remainingTime.ToString("F2");
    }

    // Update is called once per frame
    void Update()
    {
        // Game Over, early exit to avoid further updates
        if (IntroTimerFinished)
        {
            gameObject.SetActive(false);
        }
        else
        {
            // check for game over condition otherwise countdown the timer
            if (remainingTime <= 0)
            {
                remainingTime = 0;  // Ensure remainingTime doesn't go below 0
                IntroTimerFinished = true;
            }
            else
            {
                remainingTime -= Time.deltaTime;
                timerText.text = remainingTime.ToString("F0");
            }
        }
    }
}
