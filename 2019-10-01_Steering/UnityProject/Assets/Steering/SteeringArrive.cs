using UnityEngine;
using System.Collections;

public class SteeringArrive : MonoBehaviour {

	public float min_distance = 0.1f;
	public float slow_distance = 5.0f;
	public float time_to_accel = 0.1f;

	Move move;

	// Use this for initialization
	void Start () { 
		move = GetComponent<Move>();
	}

	// Update is called once per frame
	void Update () 
	{
		    Steer(move.target.transform.position);
	}

	public void Steer(Vector3 target)
	{
		if(!move)
			move = GetComponent<Move>();

        // TODO 3: Find the acceleration to achieve the desired velocity
        // If we are close enough to the target just stop moving and do nothing else
        // Calculate the desired acceleration using the velocity we want to achieve and the one we already have
        // Use time_to_target as the time to transition from the current velocity to the desired velocity
        // Clamp the desired acceleration and call move.AccelerateMovement()
        if (Vector3.Distance(transform.position, target) <= min_distance)
        {
            Vector3 desired_velocity = (target - transform.position).normalized * move.max_mov_speed;
            Vector3 curr_velocity = move.movement;

            //Stop moving
            move.SetMovementVelocity(Vector3.zero);

            //Calculate the new acceleration
            Vector3 accel_dir = desired_velocity - curr_velocity;
            float required_accel = curr_velocity.magnitude / time_to_accel;
            required_accel = Mathf.Clamp(required_accel, -move.max_mov_acceleration, move.max_mov_acceleration);
            move.AccelerateMovement(accel_dir * required_accel * Time.deltaTime);
        }
        else
        {
            //Steering seek
            Vector3 new_speed = (target - transform.position).normalized * move.max_mov_acceleration * Time.deltaTime;
            move.AccelerateMovement(new_speed);
        }


        //TODO 4: Add a slow factor to reach the target
        // Start slowing down when we get closer to the target
        // Calculate a slow factor (0 to 1 multiplier to desired velocity)
        // Once inside the slow radius, the further we are from it, the slower we go

    }

    private void OnDrawGizmos()
    {
        //Display the min radius
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(move.target.transform.position, min_distance);
    }

    void OnDrawGizmosSelected() 
	{
		// Display the explosion radius when selected
		Gizmos.color = Color.white;
		Gizmos.DrawWireSphere(transform.position, min_distance);

		Gizmos.color = Color.green;
		Gizmos.DrawWireSphere(transform.position, slow_distance);
	}
}
