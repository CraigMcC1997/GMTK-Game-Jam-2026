using UnityEngine;

public class PlayBackgroundMusic : MonoBehaviour
{
    public AudioClip musicTrack;
    private void Start()
    {
        AudioSource audioSource = GetComponent<AudioSource>();

        audioSource.clip = musicTrack;
        audioSource.loop = true;
        audioSource.Play();
    }
}
