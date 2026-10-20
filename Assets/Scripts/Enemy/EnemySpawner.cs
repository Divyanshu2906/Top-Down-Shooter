
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject enemyprefabs;
    [SerializeField] GameObject rangedenemyprefab;
    [SerializeField] Transform spawnpoints;
    [SerializeField] float spawnrate = 2f;
    [SerializeField] int enemiesperwave = 5;

    int currentwave = 1;
    int enemiesspawnedthiswave;

    float spawntimer;
    int aliveEnemies;

    void Update()
    {
        if (spawntimer > 0)
        {
            spawntimer -= Time.deltaTime;
        }
        else
        {
            if (enemiesspawnedthiswave < enemiesperwave)
            {
                SpawnEnemy();
                spawntimer = spawnrate;
                enemiesspawnedthiswave++;
            }
        }

        if (aliveEnemies == 0 &&
            enemiesspawnedthiswave >= enemiesperwave)
        {
            currentwave++;
            enemiesspawnedthiswave = 0;

            enemiesperwave = 5 + (currentwave - 1) * 2;

            Debug.Log("Starting Wave: " + currentwave);
            Debug.Log("Enemies this wave: " + enemiesperwave);
        }
    }

    void SpawnEnemy()
    {
        float rangedChance = Mathf.Min(
            0.2f + (currentwave - 1) * 0.1f,
            0.6f
        );

        GameObject selectedEnemy;

        if (Random.value < rangedChance)
        {
            selectedEnemy = rangedenemyprefab;
        }
        else
        {
            selectedEnemy = enemyprefabs;
        }

        GameObject enemy = Instantiate(
            selectedEnemy,
            spawnpoints.position,
            spawnpoints.rotation
        );

        aliveEnemies++;

        Health health = enemy.GetComponent<Health>();

        if (health != null)
        {
            health.SetSpawner(this);
            health.SetWave(currentwave);
        }
        else
        {
            Debug.LogError(
                "Spawned enemy is missing the Health component!",
                enemy
            );
        }

        RangedEnemyShooting rangedShooting = enemy.GetComponent<RangedEnemyShooting>();

        if (rangedShooting != null)
        {
            rangedShooting.SetWave(currentwave);
        }
    }

    public void EnemyDied()
    {
        aliveEnemies--;

        Debug.Log("Alive Enemies: " + aliveEnemies);
    }
}
