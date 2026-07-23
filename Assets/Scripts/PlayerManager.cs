using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;

public class PlayerManager : MonoBehaviour
{
    int currentHealth;
    int startingHealth;
    public Slider healthBar;

    public TMP_Text coinsText;
    public KeysManager keysManager;

    int currentSpeed;
    int currentShield;

    Transform shield;

    public FollowMouse followMouse;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SetHealthValue();
        SetSpeedValue();

        currentShield = 2 * PlayerPrefs.GetInt("ShieldSlotsUsed", 0);

        shield = transform.Find("Shield");
        if (shield != null)
        {
            shield.gameObject.SetActive(false);
        }

    }

    void SetHealthValue()
    {
        if (PlayerPrefs.GetInt("HealthSlotsUsed", 0) == 0)
        {
            startingHealth = 1;
        }
        else
        {
            startingHealth = 2 * PlayerPrefs.GetInt("HealthSlotsUsed", 0);
        }
        
        currentHealth = startingHealth;
        healthBar.maxValue = startingHealth;
        UpdateHealthBar();
    }

    void SetSpeedValue()
    {
        if (PlayerPrefs.GetInt("SpeedSlotsUsed", 0) == 0)
        {
            currentSpeed = 5;
        }
        else
        {
            currentSpeed = 5 + (2 * PlayerPrefs.GetInt("SpeedSlotsUsed", 0));
        }
        
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

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Spikes"))
        {
            playerTakesDamage(1);
        }

        if (collision.gameObject.name == "Key")
        {
            Destroy(collision.gameObject);
            keysManager.CollectedKey();
        }
    }

    
    // Update is called once per frame
    void Update()
    {
        //!!!! TESTING PURPOSES ONLY, REMOVE LATER
        if (Keyboard.current.dKey.wasPressedThisFrame)
        {
            playerTakesDamage(1);
        }

        if (Keyboard.current.sKey.wasPressedThisFrame)
        {
            shield.gameObject.SetActive(!shield.gameObject.activeSelf);
        }


        // enter to increase coin count by 1
        if (Keyboard.current.pKey.wasPressedThisFrame)
        {
            PlayerPrefs.SetInt("CoinCount", PlayerPrefs.GetInt("CoinCount", 0) + 10);
            coinsText.text = PlayerPrefs.GetInt("CoinCount", 0).ToString();
        }
        if (Keyboard.current.rKey.wasPressedThisFrame)
        {
            PlayerPrefs.SetInt("CoinCount", 0);
            coinsText.text = PlayerPrefs.GetInt("CoinCount", 0).ToString();
        }
    }
}
