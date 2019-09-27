using UnityEngine;
using System.Collections;

public class KinematicArrive : MonoBehaviour {

	public float min_distance = 0.1f;
	public float time_to_target = 0.25f;

	Move move;

	// Use this for initialization
	void Start () {
		move = GetComponent<Move>();
	}

	// Update is called once per frame
	void Update () 
	{
        // TODO 8: calculate the distance. If we are in min_distance radius, we stop moving
        if (Vector2.Distance(transform.position, move.target.transform.position) < min_distance)
        {
            move.SetMovementVelocity(move.mov_velocity / (time_to_target * Time.deltaTime));
            //move.SetMovementVelocity(Vector3.zero);
            //transform.position = move.target.transform.position;
        }
		// Otherwise divide the result by time_to_target (0.25 feels good)
		// Then call move.SetMovementVelocity()
	}

	void OnDrawGizmosSelected() 
	{
		// Display the explosion radius when selected
		Gizmos.color = Color.white;
		Gizmos.DrawWireSphere(transform.position, min_distance);
	}
}
