using UnityEngine;

public class SteeringAlign : MonoBehaviour {

	public float min_angle = 0.01f;
	public float slow_angle = 0.1f;
	public float time_to_target = 0.1f;

	Move move;

	// Use this for initialization
	void Start ()
    {
		move = GetComponent<Move>();
	}

	// Update is called once per frame
	void Update () 
	{
        // TODO 7: Very similar to arrive, but using angular velocities
        // Find the desired rotation and accelerate to it
        // Use Vector3.SignedAngle() to find the angle between two directions
        float desired_rotation = Vector3.SignedAngle(Vector3.forward, move.movement, Vector3.up);
        float curr_rotation = Vector3.SignedAngle(Vector3.forward, transform.forward, Vector3.up);
        Debug.Log("desired rotation " + desired_rotation);
        Debug.Log("current rotation " + curr_rotation);

        float final_rotation = desired_rotation - curr_rotation;
        final_rotation = (final_rotation % 360);
        if (Mathf.Abs(final_rotation) > 180)
        {
            float sign = Mathf.Sign(final_rotation);
            final_rotation = 360 - Mathf.Abs(final_rotation);
            final_rotation *= -sign;
        }

        Debug.Log("final rotaton" + final_rotation);
        Debug.Log("min angle " + min_angle);

        if (Mathf.Abs(final_rotation) <= min_angle)
        {
            Debug.Log("reached min angle!");
            move.SetRotationVelocity(0f);
        }
        else
        {
            //This line is not needed since we already do it in Move::Update()
            //final_rotation = Mathf.Clamp(final_rotation, -move.max_rot_acceleration, move.max_rot_acceleration);
            move.AccelerateRotation(final_rotation);
        }
    }
}
