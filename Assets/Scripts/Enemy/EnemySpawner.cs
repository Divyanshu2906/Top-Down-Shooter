using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject enemyprefabs;
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
            if(enemiesspawnedthiswave < enemiesperwave)
            {
            SpawnEnemy();
            spawntimer = spawnrate;
            enemiesspawnedthiswave++;    
            }
        }

        if(aliveEnemies == 0 && enemiesspawnedthiswave  >= enemiesperwave)
        {
            currentwave++;
            enemiesspawnedthiswave = 0;
        }
    }

    void SpawnEnemy()
    {
        GameObject enemy = Instantiate(
            enemyprefabs,
            spawnpoints.position,
            spawnpoints.rotation
        );

        aliveEnemies++;

        Health health = enemy.GetComponent<Health>();
        health.SetSpawner(this);
    }

    public void EnemyDied()
    {
        aliveEnemies--;

        Debug.Log("Alive Enemies: " + aliveEnemies);
    }
}