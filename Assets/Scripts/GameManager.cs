using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        PlayerPrefs.SetInt("Attempts", PlayerPrefs.GetInt("Attempts", 0) + 1);
    }
}
