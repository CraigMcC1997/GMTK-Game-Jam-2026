using UnityEngine;
using TMPro;

public class CoinManager : MonoBehaviour
{
    public TMP_Text coinCountText;

    public void Start()
    {
        // Initialize the coin count text with the current coin count
        if (coinCountText != null)
        {
            coinCountText.text = PlayerPrefs.GetInt("CoinCount", 0).ToString();
        }
    }
    public void TriggerEntered(int value)
    {
        PlayerPrefs.SetInt("CoinCount", PlayerPrefs.GetInt("CoinCount", 0) + value);
        Debug.Log("Total: " + PlayerPrefs.GetInt("CoinCount", 0));
        
        if (coinCountText != null)
        {
            coinCountText.text = PlayerPrefs.GetInt("CoinCount", 0).ToString();
        }
    }
}
