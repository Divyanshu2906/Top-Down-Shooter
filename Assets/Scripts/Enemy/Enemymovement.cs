using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
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

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        playerhealth = player.GetComponent<playerhealth>();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if(player == null) return;

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
                playerhealth.takedamage(damage);
                nextattacktime = Time.time + attackcooldown;
            }
        }
    }

    void FixedUpdate()
    {
        if(player == null) return;

        if (shouldchase)
        {
            ChasePlayer();
        }
        
    }

    private void ChasePlayer()
    {
        Vector2 direction = player.position - transform.position;
        direction.Normalize();

        rb.MovePosition(rb.position + direction * moveSpeed * Time.fixedDeltaTime);
    }
    
}