using UnityEngine;
using TMPro;

public class CountDownTimer : MonoBehaviour
{
    public TMP_Text timerText;
    public float startTime = 30f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        timerText.text = startTime.ToString("F2");
    }

    // Update is called once per frame
    void Update()
    {
        if (startTime >= 0)
        {
            startTime -= Time.deltaTime;
        }

        timerText.text = startTime.ToString("F2");
    }
}
