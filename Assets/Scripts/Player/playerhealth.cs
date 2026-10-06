using System.Collections;
using UnityEngine;

public class playerhealth : MonoBehaviour
{
    [SerializeField] int maxhealth = 100;
    [SerializeField] float invulnerabilityDuration = 0.5f;
    [SerializeField] float hitFlashDuration = 0.1f;

    int currenthealth;
    float invulnerabilityTimer;

    SpriteRenderer spriteRenderer;
    Color originalColor;

    void Awake()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        originalColor = spriteRenderer.color;
    }

    void Start()
    {
        currenthealth = maxhealth;
    }

    void Update()
    {
        if (invulnerabilityTimer > 0)
        {
            invulnerabilityTimer -= Time.deltaTime;
        }
    }

    public void takedamage(int damage)
    {
        if (invulnerabilityTimer > 0)
        {
            return;
        }

        currenthealth -= damage;
        invulnerabilityTimer = invulnerabilityDuration;

        StartCoroutine(HitFlash());

        Debug.Log("Player Health: " + currenthealth);

        if (currenthealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    IEnumerator HitFlash()
    {
        spriteRenderer.color = Color.red;

        yield return new WaitForSeconds(hitFlashDuration);

        spriteRenderer.color = originalColor;
    }
}