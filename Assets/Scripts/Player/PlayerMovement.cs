using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
   public Rigidbody2D rb;
   PlayerInput playerInput;
   [SerializeField] float MoveSpeed = 5f;
   

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        playerInput = GetComponent<PlayerInput>();
    }

    void FixedUpdate()
    {
        Vector2 direction = playerInput.MovementInput.normalized;
        rb.linearVelocity = direction * MoveSpeed;
    }
}
