using UnityEngine;
using TMPro;

public class StatsManager : MonoBehaviour
{
    public TMP_Text attemptsText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        attemptsText.text = "Attempts Taken: " + PlayerPrefs.GetInt("Attempts", 0).ToString();
    }
}
