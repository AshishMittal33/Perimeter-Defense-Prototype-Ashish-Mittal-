using UnityEngine;
using UnityEngine.AI;

public class Spawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform target;

    public float spawnInterval = 2f;
    public float spawnRange = 45f;
    public int maxEnemies = 15;

    private int currentEnemies = 0;

    void Start()
    {
        InvokeRepeating(nameof(SpawnEnemy), 1f, spawnInterval);
    }

    void SpawnEnemy()
    {
        // LIMIT ENEMIES (IMPORTANT)
        if (currentEnemies >= maxEnemies) return;

        Vector3 spawnPos = GetRandomEdgePosition();

        GameObject enemy = Instantiate(enemyPrefab, spawnPos, Quaternion.identity);

        // Assign target
        EnemyAI ai = enemy.GetComponent<EnemyAI>();
        if (ai != null)
        {
            ai.target = target;
        }

        // OPTIMIZE NAVMESH AGENT
        NavMeshAgent agent = enemy.GetComponent<NavMeshAgent>();
        if (agent != null)
        {
            agent.speed = 3.5f;
            agent.acceleration = 20f;
            agent.angularSpeed = 200f;
            agent.stoppingDistance = 0.5f;
            agent.autoBraking = false;

            // Reduce crowd slowdown
            agent.avoidancePriority = Random.Range(20, 80);
        }

        // Track count
        currentEnemies++;

        // Reduce count when enemy dies
        enemy.AddComponent<EnemyTracker>().Init(this);
    }

    Vector3 GetRandomEdgePosition()
    {
        float x = Random.Range(-spawnRange, spawnRange);
        float z = Random.Range(-spawnRange, spawnRange);

        if (Random.value > 0.5f)
            x = (Random.value > 0.5f) ? spawnRange : -spawnRange;
        else
            z = (Random.value > 0.5f) ? spawnRange : -spawnRange;

        return new Vector3(x, 0.5f, z);
    }

    public void OnEnemyDestroyed()
    {
        currentEnemies--;
    }
}