using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using TMPro;
using UnityEngine.InputSystem;

public class ButtonManager : MonoBehaviour
{
    public UIUpgradeSlotsManager healthSlots;
    public UIUpgradeSlotsManager speedSlots;
    public UIUpgradeSlotsManager shieldSlots;

    public UIUpgradeSlotsManager bombTimeSlots;
    public UIUpgradeSlotsManager bombRangeSlots;


    public TMP_Text coinsText;
    public TMP_Text attemptsText;
    public LevelLoader levelLoader;
    

    void Start()
    {
        coinsText.text = PlayerPrefs.GetInt("CoinCount", 0).ToString();
        attemptsText.text = "Attempts: " + PlayerPrefs.GetInt("Attempts", 0).ToString();
    }

    void Update()
    {
        //!!!!! TESTING PURPOSES ONLY, REMOVE LATER
        if (Keyboard.current.backspaceKey.wasPressedThisFrame)
        {
            PlayerPrefs.SetInt("HealthSlotsUsed", 0);
            PlayerPrefs.SetInt("SpeedSlotsUsed", 0); 
            PlayerPrefs.SetInt("ShieldSlotsUsed", 0);
            PlayerPrefs.SetInt("numShields", 0);
            PlayerPrefs.SetInt("Attempts", 0);
            PlayerPrefs.SetInt("BombTimeSlotsUsed", 0);
            PlayerPrefs.SetInt("BombRangeSlotsUsed", 0);
            PlayerPrefs.SetInt("CoinCount", 0);
            PlayerPrefs.SetInt("numBombs", 0);

            attemptsText.text = "Attempts: " + PlayerPrefs.GetInt("Attempts", 0).ToString();
            UpdateHealthSlots();
            UpdateSpeedSlots();
            UpdateShieldSlots();
            UpdateBombTimeSlots();
            UpdateBombRangeSlots();
        }
    }

    bool Spend(int value)
    {
        int currentCoins = PlayerPrefs.GetInt("CoinCount", 0);
        if (currentCoins >= value)
        {
            PlayerPrefs.SetInt("CoinCount", currentCoins - value);
            if (coinsText != null)
            {
                coinsText.text = PlayerPrefs.GetInt("CoinCount", 0).ToString();
            }
            return true;
        }
        else
        {
            Debug.Log("Not enough coins.");
            return false;
        }
    }

    public void UpdateHealthSlots()
    {
        int SpendValue = 10; // cost to upgrade health slot
        if (!Spend(SpendValue))
        {
            return; // not enough coins, exit the function
        }
        
        int healthUpgradeSlotsUsed = PlayerPrefs.GetInt("HealthSlotsUsed", 0); // get number of slots used from PlayerPrefs
        
        if (healthUpgradeSlotsUsed >= healthSlots.GetMaxSlots())
        {
            Debug.Log("All health slots are already used.");
            return;
        }

        healthUpgradeSlotsUsed++;
        PlayerPrefs.SetInt("HealthSlotsUsed", healthUpgradeSlotsUsed);

        for (int i = 0; i < healthUpgradeSlotsUsed; i++)
        {
            healthSlots.setPurchasedColor(i, Color.green);
        }
    }

    public void UpdateSpeedSlots()
    {
        int SpendValue = 10; // cost to upgrade speed slot
        if (!Spend(SpendValue))
        {
            return; // not enough coins, exit the function
        }
    
        int speedUpgradeSlotsUsed = PlayerPrefs.GetInt("SpeedSlotsUsed", 0); // get number of slots used from PlayerPrefs
        
        if (speedUpgradeSlotsUsed >= speedSlots.GetMaxSlots())
        {
            Debug.Log("All speed slots are already used.");
            return;
        }

        speedUpgradeSlotsUsed++;
        PlayerPrefs.SetInt("SpeedSlotsUsed", speedUpgradeSlotsUsed);

        for (int i = 0; i < speedUpgradeSlotsUsed; i++)
        {
            speedSlots.setPurchasedColor(i, Color.blue);
        }
    }

    public void UpdateShieldSlots()
    {
        int SpendValue = 10; // cost to upgrade shield slot
        if (!Spend(SpendValue))
        {
            return; // not enough coins, exit the function
        }
        
        int shieldUpgradeSlotsUsed = PlayerPrefs.GetInt("ShieldSlotsUsed", 0); // get number of slots used from PlayerPrefs
        
        if (shieldUpgradeSlotsUsed >= shieldSlots.GetMaxSlots())
        {
            Debug.Log("All shield slots are already used.");
            return;
        }

        shieldUpgradeSlotsUsed++;
        PlayerPrefs.SetInt("ShieldSlotsUsed", shieldUpgradeSlotsUsed);

        // if first shield slot is purchased, set numShields to 1
        if (PlayerPrefs.GetInt("ShieldSlotsUsed", 0) == 1)
        {
            PlayerPrefs.SetInt("numShields", 1);
        }

        for (int i = 0; i < shieldUpgradeSlotsUsed; i++)
        {
            shieldSlots.setPurchasedColor(i, Color.yellow);
        }
    }

    public void UpdateBombTimeSlots()
    {
        int SpendValue = 10; // cost to upgrade bomb time slot
        if (!Spend(SpendValue))
        {
            return; // not enough coins, exit the function
        }
        
        int bombTimeUpgradeSlotsUsed = PlayerPrefs.GetInt("BombTimeSlotsUsed", 0); // get number of slots used from PlayerPrefs

        if (bombTimeUpgradeSlotsUsed >= bombTimeSlots.GetMaxSlots())
        {
            Debug.Log("All bomb time slots are already used.");
            return;
        }

        bombTimeUpgradeSlotsUsed++;
        PlayerPrefs.SetInt("BombTimeSlotsUsed", bombTimeUpgradeSlotsUsed);

        for (int i = 0; i < bombTimeUpgradeSlotsUsed; i++)
        {
            bombTimeSlots.setPurchasedColor(i, Color.red);
        }
    }

    public void UpdateBombRangeSlots()
    {
        int SpendValue = 10; // cost to upgrade bomb range slot
        if (!Spend(SpendValue))
        {
            return; // not enough coins, exit the function
        }

        int bombRangeUpgradeSlotsUsed = PlayerPrefs.GetInt("BombRangeSlotsUsed", 0); // get number of slots used from PlayerPrefs

        if (bombRangeUpgradeSlotsUsed >= bombRangeSlots.GetMaxSlots())
        {
            Debug.Log("All bomb range slots are already used.");
            return;
        }

        bombRangeUpgradeSlotsUsed++;
        PlayerPrefs.SetInt("BombRangeSlotsUsed", bombRangeUpgradeSlotsUsed);

        for (int i = 0; i < bombRangeUpgradeSlotsUsed; i++)
        {
            bombRangeSlots.setPurchasedColor(i, Color.magenta);
        }
    }

    public void ExtraShield()
    {
        if (PlayerPrefs.GetInt("numShields", 0) >= 2)
        {
            Debug.Log("Already have max number of shields.");
            return; // already have max number of shields, exit the function
        }

        int SpendValue = 100; // cost to upgrade extra shield
        if (!Spend(SpendValue))
        {
            return; // not enough coins, exit the function
        }

        PlayerPrefs.SetInt("numShields", 2);

        //disable button now
        gameObject.SetActive(false);
    }

    public void buyBombs()
    {
        if (PlayerPrefs.GetInt("numBombs", 0) >= 3)
        {
            Debug.Log("Already have max number of bombs.");
            return; // already have max number of bombs, exit the function
        }

        int SpendValue = 100; // cost to upgrade extra bomb
        if (!Spend(SpendValue))
        {
            return; // not enough coins, exit the function
        }

        PlayerPrefs.SetInt("numBombs", PlayerPrefs.GetInt("numBombs", 0) + 1);

        //disable button now
        gameObject.SetActive(false);
    }

    public void LoadGame()
    {
        levelLoader.LoadGame();
    }
}
