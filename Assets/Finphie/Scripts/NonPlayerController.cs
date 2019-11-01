using UnityEngine;
using UnityEngine.AI;

public class NonPlayerController : MonoBehaviour
{
    NavMeshAgent agent;
    Animator animator;

    void Reset()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (agent.remainingDistance > agent.stoppingDistance)
        {
            agent.isStopped = false;
            animator.SetFloat("Speed", agent.velocity.sqrMagnitude);
            return;
        }

        agent.velocity = Vector3.zero;
        agent.isStopped = true;
        animator.SetFloat("Speed", 0);
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.transform.name);
    }
}