using UnityEngine;
using UnityEngine.Tilemaps;


public class Bomb : MonoBehaviour
{
    [Header("Fuse")]
    [SerializeField] private float fuseTime = 10f;

    [Header("Flashing")]
    [SerializeField] private float slowFlashRate = 0.5f;
    [SerializeField] private float fastFlashRate = 0.05f;

    private SpriteRenderer spriteRenderer;

    private Tilemap destructibleTilemap;
    
    [SerializeField] private CircleCollider2D explosionArea;

    private float timer;
    private float flashTimer;
    private float currentFlashRate;

    Color normal = Color.white;
    Color warning = new Color(1f, 0.3f, 0.3f);

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        destructibleTilemap = GameObject.Find("Walls").GetComponent<Tilemap>();

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
        DestroyTilesInRange();
        DestroyObjectsInRange();

        Destroy(gameObject);
    }

    private void DestroyObjectsInRange()
    {
        float radius = explosionArea.radius * explosionArea.transform.lossyScale.x;

        Collider2D[] objects = Physics2D.OverlapCircleAll(
            explosionArea.transform.position,
            radius
        );

        foreach (Collider2D obj in objects)
        {
            if (obj.name != "Walls" && obj.name != "Player")
            {
                Destroy(obj.gameObject);
            }

            if (obj.name == "Player")
            {
                obj.GetComponent<PlayerManager>().playerTakesDamage(5);
            }

        }
    }


    private void DestroyTilesInRange()
    {
        Bounds bounds = explosionArea.bounds;

        Vector3Int minCell = destructibleTilemap.WorldToCell(bounds.min);
        Vector3Int maxCell = destructibleTilemap.WorldToCell(bounds.max);

        float radius = explosionArea.radius * explosionArea.transform.lossyScale.x;
        Vector2 explosionCenter = explosionArea.transform.position;

        for (int x = minCell.x; x <= maxCell.x; x++)
        {
            for (int y = minCell.y; y <= maxCell.y; y++)
            {
                Vector3Int cell = new Vector3Int(x, y, 0);

                if (!destructibleTilemap.HasTile(cell))
                    continue;

                Vector2 tilePosition = destructibleTilemap.GetCellCenterWorld(cell);

                // Only remove tiles actually inside the circle
                if (Vector2.Distance(explosionCenter, tilePosition) <= radius)
                {
                    destructibleTilemap.SetTile(cell, null);
                }
            }
        }
    }
}