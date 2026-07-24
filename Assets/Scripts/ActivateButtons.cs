using UnityEngine;
using UnityEngine.UI;

public class ActivateButtons : MonoBehaviour
{
    public Button BuyShieldsbutton;
    public Button BuyBombsbutton;

    public Button ShieldUpgradebutton;
    public Button BombUpgradebutton_time;
    public Button BombUpgradebutton_range;

    void Start()
    {
        if(PlayerPrefs.GetInt("numShields", 0) == 0)
        {
            ShieldUpgradebutton.interactable = false;
        }
        else
        {
            ShieldUpgradebutton.interactable = true;
        }

        if(PlayerPrefs.GetInt("numShields", 0) >= 2)
        {
            BuyShieldsbutton.interactable = false;
        }
        else
        {
            BuyShieldsbutton.interactable = true;
        }
        
        
        if(PlayerPrefs.GetInt("numBombs", 0) == 0)
        {
            BombUpgradebutton_time.interactable = false;
            BombUpgradebutton_range.interactable = false;
        }
        else
        {
            BombUpgradebutton_time.interactable = true;
            BombUpgradebutton_range.interactable = true;
        }

        if(PlayerPrefs.GetInt("numBombs", 0) >= 3)
        {
            BuyBombsbutton.interactable = false;
        }
        else
        {
            BuyBombsbutton.interactable = true;
        }
    }

    public void BuyShield()
    {
        if (!ShieldUpgradebutton.interactable)
        {
            if (PlayerPrefs.GetInt("numShields", 0) > 0)
                ActivateShieldUpgradeButton();
        }

        if (PlayerPrefs.GetInt("numShields", 0) >= 2)
        {
            DisableShieldBuyButton();
        }
    }

    public void BuyBomb()
    {
        if (!BombUpgradebutton_time.interactable && !BombUpgradebutton_range.interactable)
        {
            if (PlayerPrefs.GetInt("numBombs", 0) > 0)
                ActivateBombUpgradeButtons();
        }

        if (PlayerPrefs.GetInt("numBombs", 0) >= 3)
        {
            DisableBombBuyButton();
        }
        
    }

    void DisableBombBuyButton()
    {
        BuyBombsbutton.interactable = false;
    }

    void DisableShieldBuyButton()
    {
        BuyShieldsbutton.interactable = false;
    }

    void ActivateShieldUpgradeButton()
    {
        ShieldUpgradebutton.interactable = true;
    }

    void ActivateBombUpgradeButtons()
    {
        BombUpgradebutton_time.interactable = true;
        BombUpgradebutton_range.interactable = true;
    }
}
