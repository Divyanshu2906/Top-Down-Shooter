using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int MaxHealth = 100;
    int CurrentHealth;
    Animator animator;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void Start()
    {
        CurrentHealth = MaxHealth;
    }

    public void EnemyTakeDamage(int damage)
    {
        CurrentHealth -= damage;
        if(CurrentHealth <= 0)
        {
            animator.SetTrigger("Death");
            
        }
    }
}
