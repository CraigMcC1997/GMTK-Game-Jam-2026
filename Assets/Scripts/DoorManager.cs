using UnityEngine;
using System.Collections.Generic;
using TMPro;

public class DoorManager : MonoBehaviour
{
    private Animator doorAnimator;
    public KeysManager keysManager; // Reference to the KeysManager script
    public List<GameObject> UnlockIcon; // Reference to the unlock icon GameObject

    public TMP_Text unlockText; // Reference to the TMP_Text component for displaying unlock status
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        doorAnimator = GetComponent<Animator>();
        unlockText.gameObject.SetActive(false); // Hide the unlock text initially
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
                unlockText.gameObject.SetActive(true);
            }
            
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            unlockText.gameObject.SetActive(false); // Hide the unlock text when the player exits the trigger
    }
}
