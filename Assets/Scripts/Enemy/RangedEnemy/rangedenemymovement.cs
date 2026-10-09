using UnityEngine;

public class RangedEnemyMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 2f;
    [SerializeField] float approachDistance = 6f;
    [SerializeField] float retreatDistance = 3f;

    [SerializeField] float separationRadius = 1f;
    [SerializeField] float separationStrength = 0.2f;
    [SerializeField] LayerMask enemyLayer;

    Rigidbody2D rb;
    Health health;
    Transform player;
    Vector2 separationDirection;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();
        health = GetComponent<Health>();
    }

    void FixedUpdate()
    {
        if (health.isdead)
            return;

        if (player == null)
            return;

        FacePlayer();

        float distance = Vector2.Distance(player.position, transform.position);

        Vector2 direction = Vector2.zero;

        if (distance > approachDistance)
        {
            direction = player.position - transform.position;
            direction.Normalize();
        }
        else if (distance < retreatDistance)
        {
            direction = transform.position - player.position;
            direction.Normalize();
        }

        Collider2D[] nearbyEnemies =
            Physics2D.OverlapCircleAll(
                transform.position,
                separationRadius,
                enemyLayer
            );

        separationDirection = Vector2.zero;

        foreach (Collider2D enemy in nearbyEnemies)
        {
            if (enemy.gameObject == gameObject)
                continue;

            Vector2 awayFromEnemy =
                (Vector2)transform.position - (Vector2)enemy.transform.position;

            separationDirection += awayFromEnemy.normalized;
        }

        direction += separationDirection * separationStrength;

        if (direction != Vector2.zero)
        {
            direction.Normalize();

            rb.MovePosition(
                rb.position + direction * moveSpeed * Time.fixedDeltaTime
            );
        }
    }

    void FacePlayer()
    {
        Vector2 direction = player.position - transform.position;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0f, 0f, angle);
    }
}