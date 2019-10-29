using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectSphere : MonoBehaviour
{
    public LayerMask mask;
    public float distance;

    private void Update()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, distance, mask);
        if (colliders.Length != 0)
        {
            Debug.Log("Gameobject detected.");
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, distance);
    }
}
