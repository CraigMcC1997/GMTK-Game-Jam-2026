using UnityEngine;
using System.Collections.Generic;

public class DoorManager : MonoBehaviour
{
    private Animator doorAnimator;
    public KeysManager keysManager; // Reference to the KeysManager script
    public List<GameObject> UnlockIcon; // Reference to the unlock icon GameObject
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        doorAnimator = GetComponent<Animator>();
        UnlockIcon[0].GetComponent<Renderer>().material.color = Color.red; // Initial color
        UnlockIcon[1].GetComponent<Renderer>().material.color = Color.red; // Initial color
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
                // update unlock the door icon
                UnlockIcon[0].GetComponent<Renderer>().material.color = Color.green; // Change the color to indicate the door is unlocked
                UnlockIcon[1].GetComponent<Renderer>().material.color = Color.green; // Change the color to indicate the door is unlocked
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
