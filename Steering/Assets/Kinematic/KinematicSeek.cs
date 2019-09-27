using UnityEngine;
using System.Collections;

public class KinematicSeek : MonoBehaviour {

	Move move;

	// Use this for initialization
	void Start () {
		move = GetComponent<Move>();
	}
	
	// Update is called once per frame
	void Update () 
	{
        // TODO 1: Set movement velocity to max speed in the direction of the target
        Vector3 direction = move.target.transform.position - transform.position;
        move.SetMovementVelocity(direction.normalized * move.max_mov_velocity);
        //move.SetMovementVelocity(direction.normalized * Mathf.Min(direction.magnitude, move.max_mov_velocity) * Time.deltaTime);direction.normalized * Mathf.Min(direction.magnitude, move.max_mov_velocity) * Time.deltaTime
    }
}
