using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// 2D에서 네비메시 사용 샘플
/// 참고 동영상 https://www.youtube.com/watch?v=SDfEytEjb5o
/// </summary>
public class MyTopDownCharacterController : MonoBehaviour
{
    public float speed = 3;

    private Animator animator;

    private NavMeshAgent navMeshAgent;

    private void Start()
    {
        animator = GetComponentInChildren<Animator>();
        navMeshAgent = GetComponent<NavMeshAgent>();

        navMeshAgent.updateUpAxis = false;
        navMeshAgent.updateRotation = false;
    }

    private void Update()
    {
        Vector3 dir = Vector3.zero;
        if (Input.GetKey(KeyCode.A))
        {
            dir.x = -1;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            dir.x = 1;
        }

        if (Input.GetKey(KeyCode.W))
        {
            dir.y = 1;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            dir.y = -1;
        }

        if (dir.x > 0)
            animator.Play("AM Player E", 0);
        else if (dir.x < 0)
            animator.Play("AM Player W", 0);
        else if (dir.y > 0)
            animator.Play("AM Player N", 0);
        else if (dir.y < 0)
            animator.Play("AM Player S", 0);

        if (dir.magnitude > 0)
            animator.Play("AM Player Move", 1);
        else
            animator.Play("AM Player Idle", 1);

        dir.Normalize();

        if (dir.magnitude > 0)
            navMeshAgent.SetDestination(transform.position + dir * (speed * Time.deltaTime));
    }
}