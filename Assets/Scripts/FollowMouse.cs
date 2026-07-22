using UnityEngine;

public class FollowMouse : MonoBehaviour
{
    private Vector2 mousePosition;
    Rigidbody2D rb;
    public float speed = 5f;

    public StartTimer startTimer;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

   void Update()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    void FixedUpdate()
    {
        if (startTimer != null && !startTimer.GetIntroTimerFinished())
        {
            return;
        }

        // // Don't move if the mouse is off-screen
        // if (Input.mousePosition.x < 0 || Input.mousePosition.x > Screen.width ||
        //     Input.mousePosition.y < 0 || Input.mousePosition.y > Screen.height)
        // {
        //     rb.linearVelocity = Vector2.zero;
        //     return;
        // }

        Vector2 direction = mousePosition - rb.position;
        rb.linearVelocity = direction.normalized * speed;
    }
}
