using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TargetNavAgentFollow : MonoBehaviour
{
    private NavMeshAgent navMeshAgent;
    public Transform target;

    private void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        navMeshAgent.updateUpAxis = false;
        navMeshAgent.updateRotation = false;
    }

    // Update is called once per frame
    private void Update()
    {
        if (target)
            navMeshAgent.SetDestination(target.position);
    }
}