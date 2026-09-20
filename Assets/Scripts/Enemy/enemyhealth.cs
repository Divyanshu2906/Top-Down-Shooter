using UnityEngine;

public class Health : MonoBehaviour
{
    AudioSource[] audiosources;
    [SerializeField] int MaxHealth = 100;
    int CurrentHealth;
    Animator animator;
    public bool isdead;
    EnemyMovement enemyMovement;

    void Awake()
    {
        animator = GetComponent<Animator>();
        audiosources = GetComponents<AudioSource>();
        enemyMovement = GetComponent<EnemyMovement>();
    }

    void Start()
    {
        CurrentHealth = MaxHealth;
    }

    public void EnemyTakeDamage(int damage,  Vector2 hitDirection)
    {
        if(isdead) return;
        CurrentHealth -= damage;
        enemyMovement.ApplyKnockback(hitDirection);
        if(CurrentHealth <= 0)
        {
            isdead = true;
            animator.SetTrigger("Death");
            audiosources[1].Play();
        }
    }

    public void DestroyEnemy()
    {
        Destroy(gameObject);
    }
}
