using UnityEngine;

public class RangedEnemyShooting : MonoBehaviour
{
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] Transform firePoint;
    [SerializeField] float shootingRange = 8f;
    [SerializeField] float fireRate = 1f;

    Transform player;
    Health health;
    float nextFireTime;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        health = GetComponent<Health>();
    }

    void Update()
    {
        if(health.isdead)
            return;
        if (player == null)
            return;

        float distance = Vector2.Distance(transform.position, player.position);

        if (distance <= shootingRange && Time.time >= nextFireTime)
        {
            Shoot();

            nextFireTime = Time.time + fireRate;
        }
    }

    void Shoot()
    {
        Vector2 direction = player.position - firePoint.position;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        Quaternion rotation = Quaternion.Euler(0f, 0f, angle);

        Instantiate(
            projectilePrefab,
            firePoint.position,
            rotation
        );
    }
}