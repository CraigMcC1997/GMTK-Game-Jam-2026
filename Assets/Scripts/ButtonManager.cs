using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using TMPro;

public class ButtonManager : MonoBehaviour
{
    public HealthSlotsManager healthSlotsManager;
    public SpeedSlotsManager speedSlotsManager;
    public ShieldSlotsManager shieldSlotsManager;

    public TMP_Text coinsText;
    

    void Start()
    {
        //!!!!! TMP reset slots for testing purposes, remove later !!!!!!!
        PlayerPrefs.SetInt("HealthSlotsUsed", 0);
        PlayerPrefs.SetInt("ShieldSlotsUsed", 0);
        PlayerPrefs.SetInt("SpeedSlotsUsed", 0);

        int currentCoins = PlayerPrefs.GetInt("CoinCount", 0);
        coinsText.text = PlayerPrefs.GetInt("CoinCount", 0).ToString();
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
        
        List<GameObject> healthSlots = healthSlotsManager.GetHealthSlots(); // get slots to update
        int healthUpgradeSlotsUsed = PlayerPrefs.GetInt("HealthSlotsUsed", 0); // get number of slots used from PlayerPrefs
        
        if (healthUpgradeSlotsUsed >= healthSlotsManager.GetMaxHealth())
        {
            Debug.Log("All health slots are already used.");
            return;
        }

        healthUpgradeSlotsUsed++;
        PlayerPrefs.SetInt("HealthSlotsUsed", healthUpgradeSlotsUsed);

        for (int i = 0; i < healthUpgradeSlotsUsed; i++)
        {
            healthSlotsManager.setPurchasedColor(i);
        }
    }

    public void UpdateSpeedSlots()
    {
        int SpendValue = 10; // cost to upgrade health slot
        if (!Spend(SpendValue))
        {
            return; // not enough coins, exit the function
        }
        
        List<GameObject> speedSlots = speedSlotsManager.GetSpeedSlots(); // get slots to update
        int speedUpgradeSlotsUsed = PlayerPrefs.GetInt("SpeedSlotsUsed", 0); // get number of slots used from PlayerPrefs
        
        if (speedUpgradeSlotsUsed >= speedSlotsManager.GetMaxSpeed())
        {
            Debug.Log("All speed slots are already used.");
            return;
        }

        speedUpgradeSlotsUsed++;
        PlayerPrefs.SetInt("SpeedSlotsUsed", speedUpgradeSlotsUsed);

        for (int i = 0; i < speedUpgradeSlotsUsed; i++)
        {
            speedSlotsManager.setPurchasedColor(i);
        }
    }

    public void UpdateShieldSlots()
    {
        int SpendValue = 10; // cost to upgrade health slot
        if (!Spend(SpendValue))
        {
            return; // not enough coins, exit the function
        }
        

        List<GameObject> shieldSlots = shieldSlotsManager.GetShieldSlots(); // get slots to update
        int shieldUpgradeSlotsUsed = PlayerPrefs.GetInt("ShieldSlotsUsed", 0); // get number of slots used from PlayerPrefs
        
        if (shieldUpgradeSlotsUsed >= shieldSlotsManager.GetMaxShield())
        {
            Debug.Log("All shield slots are already used.");
            return;
        }

        shieldUpgradeSlotsUsed++;
        PlayerPrefs.SetInt("ShieldSlotsUsed", shieldUpgradeSlotsUsed);

        for (int i = 0; i < shieldUpgradeSlotsUsed; i++)
        {
            shieldSlotsManager.setPurchasedColor(i);
        }
    }

    public void LoadGame()
    {
        SceneManager.LoadScene("Scenes/Prototype Level");
    }
}
