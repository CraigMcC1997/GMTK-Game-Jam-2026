using UnityEngine;
using TMPro;

public class CountDownTimer : MonoBehaviour
{
    public TMP_Text timerText;
    public float remainingTime = 30f;

    public Color normalColor = Color.white;
    public Color warningColor = Color.red;
    public float flashSpeed = 4f;
    bool countdownFinished = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        timerText.text = remainingTime.ToString("F2");
    }

    // Update is called once per frame
    void Update()
    {
        // Game Over, early exit to avoid further updates
        if (countdownFinished)
        {
            timerText.text = "Time's Up!";
            return;
        }
        else
        {
            // check for game over condition otherwise countdown the timer
            if (remainingTime <= 0)
            {
                remainingTime = 0;  // Ensure remainingTime doesn't go below 0
                countdownFinished = true;
            }
            else
            {
                remainingTime -= Time.deltaTime;
            }

            timerText.text = remainingTime.ToString("F2");

            if (remainingTime <= 10f)
            {
                timerText.color = (Mathf.FloorToInt(Time.time * flashSpeed) % 2 == 0)
                    ? warningColor
                    : normalColor;
            }
            else
            {
                timerText.color = normalColor;
            }
        }
    }
}
