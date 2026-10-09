using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] int damage = 25;
    [SerializeField] float lifetime = 3f;

    Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        rb.linearVelocity = transform.right * moveSpeed;

        Destroy(gameObject, lifetime);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerhealth playerHealth = collision.GetComponent<playerhealth>();

            if (playerHealth != null)
            {
                playerHealth.takedamage(damage);
            }

            Destroy(gameObject);
        }
    }
}