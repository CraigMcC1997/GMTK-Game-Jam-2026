using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    int currentHealth;
    int currentSpeed;
    int currentShield;

    public FollowMouse followMouse;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHealth = 2 * PlayerPrefs.GetInt("HealthSlotsUsed", 0);
        currentSpeed = 2 * PlayerPrefs.GetInt("SpeedSlotsUsed", 0);
        currentShield = 2 * PlayerPrefs.GetInt("ShieldSlotsUsed", 0);

        if (currentSpeed != 0)
            followMouse.SetSpeed(currentSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
