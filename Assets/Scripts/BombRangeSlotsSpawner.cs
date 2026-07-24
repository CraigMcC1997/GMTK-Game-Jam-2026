using UnityEngine;
using System.Collections.Generic;
public class BombRangeSlotsSpawner : MonoBehaviour
{
    public GameObject box;
    List<GameObject> bombRangeSlots = new List<GameObject>();
    const int MAX_BOMB_RANGE = 20;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        int bombRangeUpgradeSlotsUsed = PlayerPrefs.GetInt("BombRangeSlotsUsed", 0);

        for (int i = 0; i < MAX_BOMB_RANGE; i++)
        {
            bombRangeSlots.Add(Instantiate(box));
            bombRangeSlots[i].transform.position = new Vector3(transform.position.x + (i * 0.4f), transform.position.y, 5);

            if (i < bombRangeUpgradeSlotsUsed)
            {
                setPurchasedColor(i);
            }
        }
    }

    public void setPurchasedColor(int i)
    {
        bombRangeSlots[i].GetComponent<Renderer>().material.color = Color.yellow; // change color of used slots to yellow
    }

    public List<GameObject> GetBombRangeSlots()
    {
        return bombRangeSlots;
    }

    public int GetMaxBombRange()
    {
        return MAX_BOMB_RANGE;
    }
}