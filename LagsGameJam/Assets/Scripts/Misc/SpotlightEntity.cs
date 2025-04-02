using System.Collections;
using UnityEngine;

public class SpotlightEntity : MonoBehaviour
{
    public float lightDelay = 2f; // Delay before enabling the collider
    public float flashSpeed = 5f; // Speed of alpha flashing
    public float disableDelay = 2f; // Time before disabling the object
    private Collider2D col;
    private SpriteRenderer spriteRenderer;

    void Awake()
    {
        col = GetComponent<Collider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        col.enabled = false;
        SetAlpha(0f); // Start with fully transparent
    }

    void OnEnable()
    {
        StartCoroutine(EnableColliderAfterDelay());
    }

    IEnumerator EnableColliderAfterDelay()
    {
        float timer = 0f;

        while (timer < lightDelay)
        {
            float alpha = Mathf.PingPong(Time.time * flashSpeed, 1f); // Flash effect
            SetAlpha(alpha);
            timer += Time.deltaTime;
            yield return null;
        }

        SetAlpha(1f); // Fully visible
        col.enabled = true;

        yield return new WaitForSeconds(disableDelay); // Wait before disabling

        gameObject.SetActive(false); // Disable the object
    }

    void SetAlpha(float alpha)
    {
        if (spriteRenderer != null)
        {
            Color color = spriteRenderer.color;
            color.a = alpha;
            spriteRenderer.color = color;
        }
    }
}
