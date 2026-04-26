using UnityEngine;
using UnityEngine.AI;

public class Spawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform target;

    public Transform[] spawnPoints; 

    public float spawnInterval = 2f;
    public int maxEnemies = 15;

    private int currentEnemies = 0;

    void Start()
    {
        InvokeRepeating(nameof(SpawnEnemy), 1f, spawnInterval);
    }

    void SpawnEnemy()
    {
        if (currentEnemies >= maxEnemies) return;

      
        Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
        Vector3 spawnPos = spawnPoint.position;

        GameObject enemy = Instantiate(enemyPrefab, spawnPos, Quaternion.identity);


        EnemyAI ai = enemy.GetComponent<EnemyAI>();
        if (ai != null)
        {
            ai.target = target;
        }

        NavMeshAgent agent = enemy.GetComponent<NavMeshAgent>();
        if (agent != null)
        {
            agent.speed = Random.Range(1f, 2.0f);
            agent.acceleration = Random.Range(10f, 15f);
            agent.angularSpeed = 200f;
            agent.stoppingDistance = 0.5f;
            agent.autoBraking = false;
            agent.avoidancePriority = Random.Range(20, 80);
        }

        currentEnemies++;
        enemy.AddComponent<EnemyTracker>().Init(this);
    }

    public void OnEnemyDestroyed()
    {
        currentEnemies--;
    }
}