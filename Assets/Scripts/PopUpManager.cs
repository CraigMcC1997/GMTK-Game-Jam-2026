using UnityEngine;

public class PopUpManager : MonoBehaviour
{
    public GameObject ShieldpopUp;
    public GameObject BombpopUp;

    public AudioClip clickAUDIO;
    AudioSource audioSource;

    void Start()
    {
        ShieldpopUp.SetActive(false);
        BombpopUp.SetActive(false);
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetInt("ShieldButtonClicked", 0) == 1)
        {
            ShieldpopUp.SetActive(true);
        }

        if (PlayerPrefs.GetInt("BombButtonClicked", 0) == 1)
        {
            BombpopUp.SetActive(true);
        }
    }

    public void CloseShieldPopUp()
    {
        audioSource.PlayOneShot(clickAUDIO);
        ShieldpopUp.SetActive(false);
        PlayerPrefs.SetInt("ShieldButtonClicked", 0);
    }

    public void CloseBombPopUp()
    {
        audioSource.PlayOneShot(clickAUDIO);
        BombpopUp.SetActive(false);
        PlayerPrefs.SetInt("BombButtonClicked", 0);
    }
}
