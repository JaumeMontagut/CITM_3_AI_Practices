using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DudeController : MonoBehaviour
{
    NavMeshAgent agent;
    Transform target;
    Animator anim;
    float distStopAnimation = 0.5f;

    private void Start()
    {
        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        target = FindObjectOfType<MoveToMouseClick>().transform;
    }

    private void Update()
    {
        Vector3 trgPos = target.position;
        agent.SetDestination(trgPos);

        Vector3 anim_values = transform.InverseTransformVector(agent.desiredVelocity);

        if (anim_values != Vector3.zero)
        {
            Debug.Log(anim_values);
            anim.SetFloat("vel_x", anim_values.x);
            anim.SetFloat("vel_y", anim_values.z);
            anim.SetBool("movement", true);
        }
        else
        {
            anim.SetBool("movement", false);
        }
    }
}
