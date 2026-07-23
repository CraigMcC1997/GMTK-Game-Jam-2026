using UnityEngine;
using TMPro;

public class CountDownTimer : MonoBehaviour
{
    public TMP_Text timerText;
    public GameObject TimesUpScreen; // Reference to the TimesUpManager script
    public float remainingTime = 15f;

    public Color normalColor = Color.white;
    public Color warningColor = Color.red;

    public float flashStartTime = 10f;
    public float flashSpeed = 4f;
    bool countdownFinished = false;

    public StartTimer startTimer; // Reference to the Game Over screen

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        timerText.text = remainingTime.ToString("F2");
    }

    public bool stopTimer()
    {
        countdownFinished = true;
        return countdownFinished;
    }

    // Update is called once per frame
    void Update()
    {
        if (startTimer != null && !startTimer.GetIntroTimerFinished())
        {
            return;
        }
        
        // Game Over, early exit to avoid further updates
        if (countdownFinished)
        {
            return;
        }
        else
        {
            // check for game over condition otherwise countdown the timer
            if (remainingTime <= 0)
            {
                remainingTime = 0;  // Ensure remainingTime doesn't go below 0
                countdownFinished = true;
                TimesUpScreen.SetActive(true);
                timerText.text = "Time's Up!";
            }
            else
            {
                remainingTime -= Time.deltaTime;
            }

            // Ramp up stress by flashing timer and display milliseconds 
            if (remainingTime < flashStartTime)
            {
                timerText.text = remainingTime.ToString("F2");

                timerText.color = (Mathf.FloorToInt(Time.time * flashSpeed) % 2 == 0)
                    ? warningColor
                    : normalColor;
            }
            else
            {
                timerText.text = remainingTime.ToString("F1");
                timerText.color = normalColor;
            }
        }
    }
}
