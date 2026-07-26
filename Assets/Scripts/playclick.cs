using UnityEngine;

public class playclick : MonoBehaviour
{
    public AudioClip clickAUDIO;
    AudioSource audioSource;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayClickSound()
    {
        audioSource.PlayOneShot(clickAUDIO);
    }
}
