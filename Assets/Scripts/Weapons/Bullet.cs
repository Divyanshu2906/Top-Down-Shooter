using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float MoveSpeed = 20f;
    Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        rb.linearVelocity = transform.right * MoveSpeed;
    }
}
