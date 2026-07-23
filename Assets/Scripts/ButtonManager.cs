using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class ButtonManager : MonoBehaviour
{
    public HealthSlotsManager healthSlotsManager;
    public SpeedSlotsManager speedSlotsManager;
    public ShieldSlotsManager shieldSlotsManager;
    

    void Start()
    {
        //!!!!! TMP reset slots for testing purposes, remove later !!!!!!!
        PlayerPrefs.SetInt("HealthSlotsUsed", 0);
        PlayerPrefs.SetInt("ShieldSlotsUsed", 0);
        PlayerPrefs.SetInt("SpeedSlotsUsed", 0);
    }

    public void UpdateHealthSlots()
    {
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
