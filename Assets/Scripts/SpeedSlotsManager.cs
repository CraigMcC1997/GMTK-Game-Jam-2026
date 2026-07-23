using UnityEngine;
using System.Collections.Generic;

public class SpeedSlotsManager : MonoBehaviour
{
    public GameObject box;
    List<GameObject> speedSlots = new List<GameObject>();
    const int MAX_SPEED = 20;

    void Start()
    {
        int speedUpgradeSlotsUsed = PlayerPrefs.GetInt("SpeedSlotsUsed", 0);

        for (int i = 0; i < MAX_SPEED; i++)
        {
            speedSlots.Add(Instantiate(box));
            speedSlots[i].transform.position = new Vector3(transform.position.x + (i * 0.4f), transform.position.y, 5);

            if (i < speedUpgradeSlotsUsed)
            {
                setPurchasedColor(i);
            }
        }
    }

    public void setPurchasedColor(int i)
    {
        speedSlots[i].GetComponent<Renderer>().material.color = Color.blue; // change color of used slots to blue
    }

    public List<GameObject> GetSpeedSlots()
    {
        return speedSlots;
    }

    public int GetMaxSpeed()
    {
        return MAX_SPEED;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}