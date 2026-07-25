using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;

public class BombSpawner : MonoBehaviour
{
    public GameObject bombPrefab;
    public StartTimer startTimer;
    public TMP_Text BombsText;
    int bombsUsed = 0;

    void Start()
    {
        BombsText.text = (PlayerPrefs.GetInt("numBombs", 0) - bombsUsed).ToString();
    }


    // Update is called once per frame
    void Update()
    {
        if (!startTimer.GetIntroTimerFinished())
        {
            return; // Exit the Update method if the intro timer is not finished
        }

        if (Mouse.current != null && Mouse.current.rightButton.wasPressedThisFrame)
        {
            if (bombsUsed < PlayerPrefs.GetInt("numBombs", 0))
            {
                SpawnBomb();
            }
        }
    }

    void SpawnBomb()
    {        
        Instantiate(bombPrefab, transform.position, Quaternion.identity);
        bombsUsed++;
        BombsText.text = (PlayerPrefs.GetInt("numBombs", 0) - bombsUsed).ToString();
    }
}
