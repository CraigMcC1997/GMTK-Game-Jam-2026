using UnityEngine;

public class DoorManager : MonoBehaviour
{
    private Animator doorAnimator;
    public KeysManager keysManager; // Reference to the KeysManager script
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        doorAnimator = GetComponent<Animator>();
    }

    void OpenDoor()
    {
        if (doorAnimator != null)
        {
            doorAnimator.SetTrigger("Open");
            keysManager.UseKey();
            Debug.Log("Used a key to open the door. Remaining: " + PlayerPrefs.GetInt("KeyCount", 0));
            gameObject.GetComponent<Collider2D>().enabled = false; // Disable the collider to allow passage
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (PlayerPrefs.GetInt("KeyCount", 0) > 0)
            {
                OpenDoor();
            }
            else
            {
                Debug.Log("No keys available to open the door.");
                return; // Exit if no keys are available
            }
            
        }
    }
}
