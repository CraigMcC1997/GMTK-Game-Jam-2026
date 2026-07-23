using UnityEngine;

public class ShieldEffect : MonoBehaviour
{
    public SpriteRenderer shieldRenderer;
    public float pulseSpeed = 3f;
    public float minAlpha = 0.15f;
    public float maxAlpha = 0.45f;

    private Vector3 baseScale;

    void Start()
    {
        baseScale = transform.localScale;
    }

    void Update()
    {
        // Pulse transparency
        float alpha = Mathf.Lerp(
            minAlpha,
            maxAlpha,
            (Mathf.Sin(Time.time * pulseSpeed) + 1) / 2
        );

        Color colour = shieldRenderer.color;
        colour.a = alpha;
        shieldRenderer.color = colour;

        // Slight size pulse
        float scale = 1 + Mathf.Sin(Time.time * pulseSpeed) * 0.03f;
        transform.localScale = baseScale * scale;
    }
}
