using UnityEngine;

public class Bomb : MonoBehaviour
{
    [Header("Fuse")]
    [SerializeField] private float fuseTime = 10f;

    [Header("Flashing")]
    [SerializeField] private float slowFlashRate = 0.5f;
    [SerializeField] private float fastFlashRate = 0.05f;

    private SpriteRenderer spriteRenderer;

    private float timer;
    private float flashTimer;
    private float currentFlashRate;

    Color normal = Color.white;
    Color warning = new Color(1f, 0.3f, 0.3f);

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        // fuse gets shorter as player upgrades bomb timer        
        timer = fuseTime - (PlayerPrefs.GetInt("BombTimeSlotsUsed", 0) / 1.5f); // get fuse time from PlayerPrefs
        currentFlashRate = slowFlashRate;
    }

    void Update()
    {
        timer -= Time.deltaTime;

        // Percentage of fuse remaining
        float t = 1f - (timer / fuseTime);

        // Flash rate speeds up as timer runs down
        currentFlashRate = Mathf.Lerp(slowFlashRate, fastFlashRate, t);

        flashTimer += Time.deltaTime;

        if (flashTimer >= currentFlashRate)
        {
            flashTimer = 0;
            if (spriteRenderer.color == normal)
                spriteRenderer.color = warning;
            else
                spriteRenderer.color = normal;
        }

        if (timer <= 0)
        {
            Explode();
        }
    }

    void Explode()
    {
        spriteRenderer.enabled = true;

        // TODO:
        // Play explosion animation
        // Damage nearby enemies
        // Spawn particles
        // Destroy walls
        // Play sound

        Destroy(gameObject);
    }
}