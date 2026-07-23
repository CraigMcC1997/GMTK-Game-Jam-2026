using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    int currentHealth;
    int startingHealth;
    public Slider healthBar;

    int currentSpeed;
    int currentShield;

    public FollowMouse followMouse;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startingHealth = 2 * PlayerPrefs.GetInt("HealthSlotsUsed", 0);
        currentHealth = startingHealth;
        healthBar.maxValue = startingHealth;
        UpdateHealthBar();

        currentSpeed = 2 * PlayerPrefs.GetInt("SpeedSlotsUsed", 0);
        currentShield = 2 * PlayerPrefs.GetInt("ShieldSlotsUsed", 0);

        if (currentSpeed != 0)
            followMouse.SetSpeed(currentSpeed);
    }

    void UpdateHealthBar()
    {
        healthBar.value = currentHealth;
    }

    public void playerTakesDamage(int damage)
    {
        //hitSound.Play(); // Play the hit sound effect
        currentHealth -= damage;
        UpdateHealthBar();
        //checkForDeath();
    }

    
    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            playerTakesDamage(1);
        }
    }
}
