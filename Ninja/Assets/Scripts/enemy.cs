using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemy : MonoBehaviour
{
    public Transform[] movespots;

    public NavMeshAgent navMeshAgent;
    [SerializeField]
    private int current_spot = 1;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        navMeshAgent.SetDestination(movespots[1].position);
    }

    void Update()
    {
        enemymovement();
    }

    private void enemymovement()
    {
        if(navMeshAgent.remainingDistance < navMeshAgent.stoppingDistance)
        {
            current_spot = (current_spot + 1) % movespots.Length;
            navMeshAgent.SetDestination(movespots[current_spot].position);
        }
    }
}
