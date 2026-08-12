using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private InputActions inputActions;
    private Vector2 movementInput;
    public Vector2 MovementInput => movementInput;
    void Awake()
    {
        inputActions = new InputActions();

    }

    void OnEnable()
    {
        inputActions.Enable();
    }

    void OnDisable()
    {
        inputActions.Disable();
    }
    
    void Update()
    {
        movementInput =  inputActions.Player.Move.ReadValue<Vector2>();
    }
}