using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.AI;

public class NavMeshController : MonoBehaviour
{
    NavMeshAgent agent;
    Transform target;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        target = FindObjectOfType<MoveToMouseClick>().transform;
    }

    private void Update()
    {
        agent.destination = target.position;
    }
}
