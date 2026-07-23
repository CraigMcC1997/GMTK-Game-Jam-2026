using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public class ShieldManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameObject.SetActive(false);
    }

    public float activeTime = 0f;

    private void OnEnable()
    {
        activeTime = PlayerPrefs.GetInt("ShieldSlotsUsed", 0) * 0.5f; // Each shield slot adds 0.5 seconds of active time
        StartCoroutine(ShieldTimer());
    }

    IEnumerator ShieldTimer()
    {
        yield return new WaitForSeconds(activeTime);

        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
