using UnityEngine;
using System.Collections.Generic;
public class BombTimeSlotsSpawner : MonoBehaviour
{
    public GameObject box;
    List<GameObject> bombTimeSlots = new List<GameObject>();
    const int MAX_BOMB_TIME = 20;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        int bombTimeUpgradeSlotsUsed = PlayerPrefs.GetInt("BombTimeSlotsUsed", 0);

        for (int i = 0; i < MAX_BOMB_TIME; i++)
        {
            bombTimeSlots.Add(Instantiate(box));
            bombTimeSlots[i].transform.position = new Vector3(transform.position.x + (i * 0.4f), transform.position.y, 5);

            if (i < bombTimeUpgradeSlotsUsed)
            {
                setPurchasedColor(i);
            }
        }
    }

    public void setPurchasedColor(int i)
    {
        bombTimeSlots[i].GetComponent<Renderer>().material.color = Color.yellow; // change color of used slots to yellow
    }

    public List<GameObject> GetBombTimeSlots()
    {
        return bombTimeSlots;
    }

    public int GetMaxBombTime()
    {
        return MAX_BOMB_TIME;
    }
}