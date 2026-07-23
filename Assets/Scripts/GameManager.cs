using UnityEngine;

public class GameManager : MonoBehaviour
{
    public PlayerManager player;
    public DeathManager deathManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        PlayerPrefs.SetInt("Attempts", PlayerPrefs.GetInt("Attempts", 0) + 1);
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
