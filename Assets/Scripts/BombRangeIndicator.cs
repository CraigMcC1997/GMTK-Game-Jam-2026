using UnityEngine;
using System.Collections.Generic;

public class BombRangeIndicator : MonoBehaviour
{
    float bombRange;
    public List<Collider2D> ObjectsInRange = new();
    void Start()
    {
       SetBombRange();
    }

    void SetBombRange()
    {
        int slotsUsed = PlayerPrefs.GetInt("BombRangeSlotsUsed", 0);
        Debug.Log($"slotsUsed = {slotsUsed}");

        bombRange = 2 + (slotsUsed * 0.5f); // base range of 2, increase by 0.5 for each slot used

        Debug.Log($"bombRange = {bombRange}");

        transform.localScale = new Vector3(bombRange, bombRange, 1f);
    }

    

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!ObjectsInRange.Contains(other))
            ObjectsInRange.Add(other);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        ObjectsInRange.Remove(other);
    }
}
