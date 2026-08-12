using UnityEngine;

public class BulletImpact : MonoBehaviour
{
    [SerializeField] float Lifetime = 1.5f;
    void Start()
    {
        Destroy(gameObject,Lifetime);
    }
}
