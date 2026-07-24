using UnityEngine;

public class BombRangeIndicator : MonoBehaviour
{
    int bombRange;
    void Start()
    {
       SetBombRange();
    }

    void SetBombRange()
    {
        int slotsUsed = PlayerPrefs.GetInt("BombRangeSlotsUsed", 0);
        Debug.Log($"slotsUsed = {slotsUsed}");

        bombRange = 2 + (slotsUsed * 2);

        Debug.Log($"bombRange = {bombRange}");

        transform.localScale = new Vector3(bombRange, bombRange, 1f);
    }
}
