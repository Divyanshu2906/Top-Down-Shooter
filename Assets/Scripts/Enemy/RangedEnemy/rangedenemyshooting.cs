
using UnityEngine;

public class RangedEnemyShooting : MonoBehaviour
{
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] Transform firePoint;
    [SerializeField] float shootingRange = 8f;
    [SerializeField] float fireRate = 1f;
    [SerializeField] int baseProjectileDamage = 15;

    Transform player;
    Health health;
    float nextFireTime;
    int projectileDamage = 15;

    void Awake()
    {
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");

        if (playerObject != null)
        {
            player = playerObject.transform;
        }

        health = GetComponent<Health>();
    }

    void Update()
    {
        if (health == null || health.isdead)
            return;

        if (player == null || firePoint == null)
            return;

        float distance = Vector2.Distance(transform.position, player.position);

        if (distance <= shootingRange && Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + fireRate;
        }
    }

    public void SetWave(int wave)
    {
        projectileDamage = baseProjectileDamage + (wave - 1) * 2;
    }

    void Shoot()
    {
        Vector2 direction = player.position - firePoint.position;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.Euler(0f, 0f, angle);

        GameObject projectile = Instantiate(
            projectilePrefab,
            firePoint.position,
            rotation
        );

        EnemyProjectile enemyProjectile = projectile.GetComponent<EnemyProjectile>();

        if (enemyProjectile != null)
        {
            enemyProjectile.SetDamage(projectileDamage);
        }
    }
}
