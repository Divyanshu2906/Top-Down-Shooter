using UnityEngine;

public class playerhealth : MonoBehaviour
{
    [SerializeField] int maxhealth = 100;
    int currenthealth;
 
    void Start()
    {
        currenthealth = maxhealth;
    }

    public void takedamage(int damage)
    {
       
        currenthealth -= damage;
        Debug.Log("Player Health: " + currenthealth);
        if(currenthealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
