using UnityEngine;
using System.Collections;
using UnityEngine.InputSystem;

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

        //!!!! TESTING PURPOSES ONLY, REMOVE LATER
        if (Keyboard.current.hKey.wasPressedThisFrame)
        {
            ShieldHit();
        }
    }

    public void ShieldHit()
    {
        StartCoroutine(ShieldHitEffect());
    }

    IEnumerator ShieldHitEffect()
    {
        // Flash bright
        shieldRenderer.color = Color.white;

        // Expand slightly
        transform.localScale = baseScale * 1.2f;

        yield return new WaitForSeconds(0.1f);

        // Return to normal
        transform.localScale = baseScale;

        // Restore normal alpha
        Color colour = shieldRenderer.color;
        colour.a = minAlpha;
        shieldRenderer.color = colour;
    }
}
