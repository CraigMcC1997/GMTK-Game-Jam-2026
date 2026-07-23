using UnityEngine;

public class CoinTriggerBox : MonoBehaviour
{
    public CoinManager coinManager;
    public int value = 1;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            coinManager.TriggerEntered(value);
            Destroy(gameObject);
        }
    }
}
