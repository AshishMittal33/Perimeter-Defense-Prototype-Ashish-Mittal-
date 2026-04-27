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
    public LineRenderer laser;

    public enum TargetPriority
    {
        Closest,
        HighestHealth
    }

    public TargetPriority priorityMode = TargetPriority.Closest;

    void Update()
    {
        DetectEnemies();

        if (currentTarget != null)
        {
            RotateTowardsTarget();
            Shoot();
        }
        else
        {
            DisableLaser();
        }
    }

    void DetectEnemies()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, detectionRadius, enemyLayer);

        Transform bestTarget = null;

        float bestValue = (priorityMode == TargetPriority.Closest) ? Mathf.Infinity : -Mathf.Infinity;

        foreach (Collider hit in hits)
        {
            float dist = Vector3.Distance(transform.position, hit.transform.position);

            Health hp = hit.GetComponent<Health>();
            float healthValue = hp != null ? hp.hp : 0f;

            if (priorityMode == TargetPriority.Closest)
            {
                if (dist < bestValue)
                {
                    bestValue = dist;
                    bestTarget = hit.transform;
                }
            }
            else if (priorityMode == TargetPriority.HighestHealth)
            {
                if (healthValue > bestValue)
                {
                    bestValue = healthValue;
                    bestTarget = hit.transform;
                }
            }
        }

        currentTarget = bestTarget;
    }

    void RotateTowardsTarget()
    {
        Vector3 dir = currentTarget.position - transform.position;
        dir.y = 0;

        Quaternion lookRot = Quaternion.LookRotation(dir);
        transform.rotation = Quaternion.Lerp(transform.rotation, lookRot, Time.deltaTime * rotationSpeed);
    }

    void Shoot()
    {
        if (currentTarget == null)
        {
            DisableLaser();
            return;
        }
        fireTimer += Time.deltaTime;

        if (fireTimer >= 1f / fireRate)
        {
            fireTimer = 0f;

            RaycastHit hit;

            Vector3 start = transform.position + new Vector3(0, 0.35f, 0);
            Vector3 end = start + transform.forward * detectionRadius;

            if (Physics.Raycast(start, transform.forward, out hit, detectionRadius))
            {
                end = hit.point;

                if (hit.collider.CompareTag("Enemy"))
                {
                    hit.collider.GetComponent<Health>().TakeDamage(damage);
                }
            }

            
            laser.SetPosition(0, start);
            laser.SetPosition(1, end);

        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }

    void DisableLaser()
    {
        laser.SetPosition(0, Vector3.zero);
        laser.SetPosition(1, Vector3.zero);
    }

}