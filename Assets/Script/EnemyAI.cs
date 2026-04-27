using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    private NavMeshAgent agent;
    public Transform target;
    Animator anim;


    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(target.position);
        anim = GetComponentInChildren<Animator>();

    }

    private void Update()
    {
        float speed = agent.velocity.magnitude;
        anim.SetFloat("Speed", speed);
    }
}