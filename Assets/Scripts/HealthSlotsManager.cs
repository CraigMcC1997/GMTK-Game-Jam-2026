using UnityEngine;
using System.Collections.Generic;

public class HealthSlotsManager : MonoBehaviour
{
    public GameObject box;
    List<GameObject> healthSlots = new List<GameObject>();
    const int MAX_HEALTH = 20;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        int healthUpgradeSlotsUsed = PlayerPrefs.GetInt("HealthSlotsUsed", 0); 


        for (int i = 0; i < MAX_HEALTH; i++)
        {
            healthSlots.Add(Instantiate(box));
            healthSlots[i].transform.position = new Vector3(transform.position.x + (i * 0.4f), transform.position.y, 5);

            if (i < healthUpgradeSlotsUsed)
            {
                setPurchasedColor(i);
            }
        }
    }

    public void setPurchasedColor(int i)
    {
        healthSlots[i].GetComponent<Renderer>().material.color = Color.green; // change color of used slots to green
    }

    public List<GameObject> GetHealthSlots()
    {
        return healthSlots;
    }

    public int GetMaxHealth()
    {
        return MAX_HEALTH;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
