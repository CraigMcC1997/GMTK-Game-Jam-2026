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
        for (int i = 0; i < MAX_SHIELD; i++)
        {
            shieldSlots.Add(Instantiate(box));
            shieldSlots[i].transform.position = new Vector3(transform.position.x + (i * 0.4f), transform.position.y, 5);
        }
    }

    public List<GameObject> GetShieldSlots()
    {
        return shieldSlots;
    }
    
    public int GetMaxShield()
    {
        return MAX_SHIELD;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
