using NUnit.Framework;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    AudioSource[] audiosources;
    [SerializeField] float separationRadius = 1.0f;
    [SerializeField] float separationStrength = 0.2f;
    [SerializeField] LayerMask enemyLayer;
    Vector2 separationDirection;
    [SerializeField] float moveSpeed = 2f;
    [SerializeField] float attackrange = 1.5f;
    [SerializeField] float attackcooldown = 1f;
    float nextattacktime;
    Animator animator;
    bool shouldchase;
    Rigidbody2D rb;
    playerhealth playerhealth;
    int damage = 25;
    Transform player;
    Health health;
    

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        playerhealth = player.GetComponent<playerhealth>();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        health = GetComponent<Health>();
        audiosources = GetComponents<AudioSource>();
    }

    void Update()
    {
        if(player == null || health.isdead) return;

        float distance = Vector2.Distance(player.position, transform.position);
        if (distance > attackrange)
        {
            shouldchase = true;
            animator.SetBool("Ismoving", shouldchase);
        }
        else
        {
            shouldchase = false;
            if(Time.time > nextattacktime)
            {
                animator.SetTrigger("Attack");
                audiosources[0].Play();
                playerhealth.takedamage(damage);
                nextattacktime = Time.time + attackcooldown;
            }
        }
    }
    

    void FixedUpdate()
    {
        if(player == null || health.isdead) return;

        if (shouldchase)
        {
            ChasePlayer();
        }
        
    }

    private void ChasePlayer()
    {
        Vector2 direction = player.position - transform.position;
        direction.Normalize();
        Collider2D[] nearbyEnemies =
        Physics2D.OverlapCircleAll(transform.position, separationRadius, enemyLayer);

        separationDirection = Vector2.zero;

        foreach (Collider2D enemy in nearbyEnemies)
        {
            if (enemy.gameObject == gameObject)
                continue;

            Vector2 awayFromEnemy = (Vector2)transform.position - (Vector2)enemy.transform.position;
            separationDirection += awayFromEnemy.normalized;
        }

        direction += separationDirection * separationStrength;
        direction.Normalize();
        rb.MovePosition(rb.position + direction * moveSpeed * Time.fixedDeltaTime);
    }
    
}