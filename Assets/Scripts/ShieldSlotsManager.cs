using UnityEngine;
using System.Collections.Generic;
public class ShieldSlotsManager : MonoBehaviour
{
    public GameObject box;
    List<GameObject> shieldSlots = new List<GameObject>();
    const int MAX_SHIELD = 20;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        int shieldUpgradeSlotsUsed = PlayerPrefs.GetInt("ShieldSlotsUsed", 0);

        for (int i = 0; i < MAX_SHIELD; i++)
        {
            shieldSlots.Add(Instantiate(box));
            shieldSlots[i].transform.position = new Vector3(transform.position.x + (i * 0.4f), transform.position.y, 5);

            if (i < shieldUpgradeSlotsUsed)
            {
                setPurchasedColor(i);
            }
        }
    }

    public void setPurchasedColor(int i)
    {
        shieldSlots[i].GetComponent<Renderer>().material.color = Color.yellow; // change color of used slots to yellow
    }

    public List<GameObject> GetShieldSlots()
    {
        return shieldSlots;
    }

    public int GetMaxShield()
    {
        return MAX_SHIELD;
    }
}
