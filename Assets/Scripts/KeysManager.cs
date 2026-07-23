using UnityEngine;
using TMPro;

public class KeysManager : MonoBehaviour
{
    public TMP_Text keysCountText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Initialize the coin count text with the current coin count
        if (keysCountText != null)
        {
            keysCountText.text = PlayerPrefs.GetInt("KeyCount", 0).ToString();
        }
    }

    public void CollectedKey()
    {
        PlayerPrefs.SetInt("KeyCount", PlayerPrefs.GetInt("KeyCount", 0) + 1);
        Debug.Log("Total: " + PlayerPrefs.GetInt("KeyCount", 0));

        if (keysCountText != null)
        {
            keysCountText.text = PlayerPrefs.GetInt("KeyCount", 0).ToString();
        }
    }

    public void UseKey()
    {
        int currentKeys = PlayerPrefs.GetInt("KeyCount", 0);
        if (currentKeys > 0)
        {
            PlayerPrefs.SetInt("KeyCount", currentKeys - 1);
            Debug.Log("Used a key. Remaining: " + PlayerPrefs.GetInt("KeyCount", 0));

            if (keysCountText != null)
            {
                keysCountText.text = PlayerPrefs.GetInt("KeyCount", 0).ToString();
            }
        }
        else
        {
            Debug.Log("No keys available to use.");
        }
    }
}
