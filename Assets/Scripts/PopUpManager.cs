using UnityEngine;

public class PopUpManager : MonoBehaviour
{
    public GameObject ShieldpopUp;
    public GameObject BombpopUp;

    void Start()
    {
        ShieldpopUp.SetActive(false);
        BombpopUp.SetActive(false);
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
        ShieldpopUp.SetActive(false);
        PlayerPrefs.SetInt("ShieldButtonClicked", 0);
    }

    public void CloseBombPopUp()
    {
        BombpopUp.SetActive(false);
        PlayerPrefs.SetInt("BombButtonClicked", 0);
    }
}
