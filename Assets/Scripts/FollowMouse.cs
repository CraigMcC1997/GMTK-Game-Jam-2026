using UnityEngine;

public class FollowMouse : MonoBehaviour
{
    private Vector2 mousePosition;
    Rigidbody2D rb;
    public float speed = 5f;

    bool isFollowingMouse = true;

    public void SetFollowingMouse(bool follow)
    {
        isFollowingMouse = follow;
    }


    public void SetSpeed(float newSpeed)
    {
        speed = newSpeed;
    }
    
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
        if (!isFollowingMouse)
        {
            rb.linearVelocity = Vector2.zero;
            return;
        }

        // if mouse close to the player, stop moving
        if (Vector2.Distance(mousePosition, rb.position) < gameObject.GetComponent<CircleCollider2D>().radius)
        {
            rb.linearVelocity = Vector2.zero;
            return;
        }
        
        Vector2 direction = mousePosition - rb.position;
        rb.linearVelocity = direction.normalized * speed;
    }
}
