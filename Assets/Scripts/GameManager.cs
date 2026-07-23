using UnityEngine;

public class GameManager : MonoBehaviour
{
    public PlayerManager player;
    public DeathManager deathManager;
    public GameObject pauseMenuUI;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        PlayerPrefs.SetInt("Attempts", PlayerPrefs.GetInt("Attempts", 0) + 1);
        //!!!!!! required when testing the intro timer
        //pauseMenuUI.SetActive(true);
    }

    void Update()
    {
        if (player.checkForDeath())
        {
            // Handle game over logic here
            Debug.Log("Game Over");
            deathManager.gameObject.SetActive(true);
        }
    }
}
