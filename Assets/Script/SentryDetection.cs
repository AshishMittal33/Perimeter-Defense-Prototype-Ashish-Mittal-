using UnityEngine;

public class SentryDetection : MonoBehaviour
{
    public float detectionRadius = 20f;
    public LayerMask enemyLayer;

    public Transform currentTarget;

    public float rotationSpeed = 5f;
    public float fireRate = 1f;
    public float damage = 25f;

    private float fireTimer;

    void Update()
    {
        DetectEnemies();

        if (currentTarget != null)
        {
            RotateTowardsTarget();
            Shoot();
        }
    }

    void DetectEnemies()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, detectionRadius, enemyLayer);

        float closestDist = Mathf.Infinity;
        Transform bestTarget = null;

        foreach (Collider hit in hits)
        {
            float dist = Vector3.Distance(transform.position, hit.transform.position);

            if (dist < closestDist)
            {
                closestDist = dist;
                bestTarget = hit.transform;
            }
        }

        currentTarget = bestTarget;
    }

    void RotateTowardsTarget()
    {
        Vector3 dir = currentTarget.position - transform.position;
        dir.y = 0; // keep rotation horizontal

        Quaternion lookRot = Quaternion.LookRotation(dir);
        transform.rotation = Quaternion.Lerp(transform.rotation, lookRot, Time.deltaTime * rotationSpeed);
    }

    void Shoot()
    {
        fireTimer += Time.deltaTime;

        if (fireTimer >= 1f / fireRate)
        {
            fireTimer = 0f;

            RaycastHit hit;
            if (Physics.Raycast(transform.position + Vector3.up, transform.forward, out hit, detectionRadius))
            {
                if (hit.collider.CompareTag("Enemy"))
                {
                    hit.collider.GetComponent<Health>().TakeDamage(damage);
                }
            }
        }
        Debug.DrawRay(transform.position + Vector3.up, transform.forward * detectionRadius, Color.green);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
}