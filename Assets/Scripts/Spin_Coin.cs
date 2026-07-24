using UnityEngine;

public class Spin_Coin : MonoBehaviour
{
    public float rotationSpeed = 100f;
    public float bobHeight = 0.15f;
    public float bobSpeed = 2f;
    Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        transform.Rotate(0f, rotationSpeed * Time.deltaTime, 0f);
        transform.position = startPosition + Vector3.up * Mathf.Sin(Time.time * bobSpeed) * bobHeight;
    }
}
