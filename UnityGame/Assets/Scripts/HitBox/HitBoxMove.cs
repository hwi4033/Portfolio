using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class HitBoxMove : MonoBehaviour
{
    [SerializeField] NavMeshAgent navMeshAgent;

    [SerializeField] float speed = 3.0f;

    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    public void Move(Vector3 player)
    {
        navMeshAgent.SetDestination(player);
        // rigidBody.position = Vector3.MoveTowards(gameObject.transform.position, player, speed * Time.deltaTime);
        // rigidBody.MovePosition(rigidBody.position + player * speed * Time.deltaTime);
        // transform.position = Vector3.MoveTowards(transform.position, player, speed * Time.deltaTime);
    }
}