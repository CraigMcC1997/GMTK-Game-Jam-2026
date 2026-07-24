using UnityEngine;
using System.Collections.Generic;

public class UIUpgradeSlotsManager : MonoBehaviour
{
    public string upgradeType;
    public GameObject box;
    List<GameObject> slots = new List<GameObject>();
    const int MAX_COUNT = 20;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        int numSlotsUsed = 0;
        switch(upgradeType)
        {
            case "Health":
                numSlotsUsed = PlayerPrefs.GetInt("HealthSlotsUsed", 0);
                setPurchasedSlots(numSlotsUsed, Color.green);
                break;
            case "Speed":
                numSlotsUsed = PlayerPrefs.GetInt("SpeedSlotsUsed", 0); 
                setPurchasedSlots(numSlotsUsed, Color.blue);
                break;
            case "Shield":
                numSlotsUsed = PlayerPrefs.GetInt("ShieldSlotsUsed", 0);
                setPurchasedSlots(numSlotsUsed, Color.yellow);
                break;
            case "BombTime":
                numSlotsUsed = PlayerPrefs.GetInt("BombTimeSlotsUsed", 0);
                setPurchasedSlots(numSlotsUsed, Color.red);
                break;
            case "BombRange":
                numSlotsUsed = PlayerPrefs.GetInt("BombRangeSlotsUsed", 0);
                setPurchasedSlots(numSlotsUsed, Color.magenta);
                break;
        }
    }

    void setPurchasedSlots(int numSlotsUsed, Color color)
    {
        for (int i = 0; i < MAX_COUNT; i++)
        {
            slots.Add(Instantiate(box));
            slots[i].transform.position = new Vector3(transform.position.x + (i * 0.4f), transform.position.y, 5);

            if (i < numSlotsUsed)
            {
                setPurchasedColor(i, color);
            }
        }
    }

    public void setPurchasedColor(int i, Color color)
    {
        slots[i].GetComponent<Renderer>().material.color = color; // change color of used slots to specified color
    }

    public List<GameObject> GetSlots()
    {
        return slots;
    }

    public int GetMaxSlots()
    {
        return MAX_COUNT;
    }
}
