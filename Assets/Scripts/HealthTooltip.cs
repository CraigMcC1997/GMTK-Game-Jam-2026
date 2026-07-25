using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;

public class HealthTooltip : MonoBehaviour
{
    public TMP_Text tooltipText;
    public string tooltipMessage;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        tooltipText.text = tooltipMessage;
    }

    // Update is called once per frame
    void Update()
    {
        if (Mouse.current != null && Mouse.current.position.ReadValue().x >= 0 && Mouse.current.position.ReadValue().y >= 0)
        {
            tooltipText.gameObject.SetActive(true);
        }
        else
        {
            tooltipText.gameObject.SetActive(false);
        }
    }
}
