using UnityEngine;

public class FollowMouse : MonoBehaviour
{
    private Vector2 mousePosition;
    Rigidbody2D rb;
    public float speed = 5f;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector2 direction = mousePosition - rb.position;

        rb.linearVelocity = direction.normalized * speed;
        //transform.position = new Vector3(mousePosition.x, mousePosition.y, 0);
    }
}
