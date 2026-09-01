using UnityEngine;

public class Health : MonoBehaviour
{
    AudioSource[] audiosources;
    [SerializeField] int MaxHealth = 100;
    int CurrentHealth;
    Animator animator;
    public bool isdead;

    void Awake()
    {
        animator = GetComponent<Animator>();
        audiosources = GetComponents<AudioSource>();
    }

    void Start()
    {
        CurrentHealth = MaxHealth;
    }

    public void EnemyTakeDamage(int damage)
    {
        if(isdead) return;
        CurrentHealth -= damage;
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
