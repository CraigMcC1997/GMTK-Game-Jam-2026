using UnityEngine;

public class BombSpawner : MonoBehaviour
{
    public GameObject bombPrefab;
    int bombsUsed = 0;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if (bombsUsed < PlayerPrefs.GetInt("numBombs", 0))
            {
                SpawnBomb();
            }
        }
    }

    void SpawnBomb()
    {        
        Instantiate(bombPrefab, transform.position, Quaternion.identity);
        bombsUsed++;
    }
}
