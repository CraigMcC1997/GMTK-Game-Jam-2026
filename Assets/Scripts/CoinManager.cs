using UnityEngine;

public class CoinManager : MonoBehaviour
{
    public void TriggerEntered(int value)
    {
        PlayerPrefs.SetInt("CoinCount", PlayerPrefs.GetInt("CoinCount", 0) + value);
        Debug.Log("Total: " + PlayerPrefs.GetInt("CoinCount", 0));
    }
}
