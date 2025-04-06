using System.Collections;
using UnityEngine;

public class DeathHitbox : MonoBehaviour
{
    private Coroutine deactivateRoutine;
    private Collider2D col;
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        col = GetComponent<Collider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        if (col != null) col.enabled = false;
        if (spriteRenderer != null) spriteRenderer.enabled = false;
    }

    public void ActivateTemporarily()
    {
        if (col != null) col.enabled = true;
        if (spriteRenderer != null) spriteRenderer.enabled = true;

        if (deactivateRoutine != null)
            StopCoroutine(deactivateRoutine);

        deactivateRoutine = StartCoroutine(DeactivateAfterTime(0.1f));
    }

    private IEnumerator DeactivateAfterTime(float seconds)
    {
        yield return new WaitForSeconds(seconds);

        if (col != null) col.enabled = false;
        if (spriteRenderer != null) spriteRenderer.enabled = false;
    }
}
