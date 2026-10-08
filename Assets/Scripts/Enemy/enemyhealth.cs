using UnityEngine;

public class Health : MonoBehaviour
{
    AudioSource[] audiosources;
    [SerializeField] int MaxHealth = 100;

    int CurrentHealth;
    Animator animator;
    public bool isdead;

    EnemySpawner enemySpawner;

    void Awake()
    {
        animator = GetComponent<Animator>();
        audiosources = GetComponents<AudioSource>();
    }

    void Start()
    {
        CurrentHealth = MaxHealth;
    }

    public void SetSpawner(EnemySpawner spawner)
    {
        enemySpawner = spawner;
    }

    public void EnemyTakeDamage(int damage, Vector2 hitDirection)
    {
        if (isdead) return;

        CurrentHealth -= damage;

        EnemyMovement enemyMovement = GetComponent<EnemyMovement>();

        if (enemyMovement != null)
        {
            enemyMovement.ApplyKnockback(hitDirection);
        }

        if (CurrentHealth <= 0)
        {
            isdead = true;

            enemySpawner.EnemyDied();

            animator.SetTrigger("Death");
            audiosources[1].Play();
        }
    }

    public void DestroyEnemy()
    {
        Destroy(gameObject);
    }
}