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
    public ShieldManager shield;

    int currentSpeed;
    int currentShield = 0;
    int shieldsUsed = 0;

    public FollowMouse followMouse;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SetHealthValue();
        SetSpeedValue();
        SetShieldValue();
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

    void SetShieldValue()
    {
        // no Shield, don't allow use.
        if (PlayerPrefs.GetInt("ShieldSlotsUsed", 0) == 0)
        {
            currentShield = 0;
        }
        else
        {
            currentShield = 2 * PlayerPrefs.GetInt("ShieldSlotsUsed", 0);
        }
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
            if (!shield.gameObject.activeSelf)
            {
                playerTakesDamage(1);
            }
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

        // Activate shield.
        if (Keyboard.current.sKey.wasPressedThisFrame)
        {
            if (PlayerPrefs.GetInt("numShields", 0) > 0)
            {
                if (shieldsUsed < PlayerPrefs.GetInt("numShields", 0))
                {
                    shieldsUsed++;
                    shield.gameObject.SetActive(true);
                }
                else
                {
                    Debug.Log("No more shields available.");
                }
            }
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
