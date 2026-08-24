using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float MoveSpeed = 20f;
    [SerializeField] float BulletLiftime = 3f;
    [SerializeField] GameObject Impacteffectprefab;
    [SerializeField] int damage = 25;
    Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        rb.linearVelocity = transform.right * MoveSpeed;
        Destroy(gameObject,BulletLiftime);
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Wall"))
        {
            Instantiate(Impacteffectprefab,transform.position,Quaternion.identity);
            Destroy(gameObject);
        }
        Health health = other.GetComponent<Health>();

            if(health != null)
            {
                health.EnemyTakeDamage(damage); //this function originally belongs to health class, the damage is only known to the bullet script
                Destroy(gameObject);
            }
    }
}
