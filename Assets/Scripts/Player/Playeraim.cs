using UnityEngine;
using UnityEngine.InputSystem;

public class Playeraim : MonoBehaviour
{
    void Update()
    {
        Vector2 mouseScreenPosition = Mouse.current.position.ReadValue(); //gets the exact value of the cursor on the screen
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(mouseScreenPosition); //convert the screen position to in game world position
        
        mousePosition.z = 0f; //it is a 2D game 

        Vector3 direction = mousePosition - transform.position; //give the direction to the player 

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg; //atan2 is used to calculate the angle

        transform.rotation = Quaternion.Euler(0f, 0f, angle); //rotation on Z axis only
    }
}
