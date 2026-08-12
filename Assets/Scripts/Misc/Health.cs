using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int MaxHealth = 100;
    int CurrentHealth;

    void Start()
    {
        CurrentHealth = MaxHealth;
    }

    public void TakeDamage(int damage)
    {
        CurrentHealth -= damage;
        if(CurrentHealth < 0)
        {
            Destroy(gameObject);
        }
    }
}
