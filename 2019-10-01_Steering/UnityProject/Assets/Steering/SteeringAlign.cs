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
        float curr_rotation = transform.localRotation.eulerAngles.y;

        float final_rotation = desired_rotation - curr_rotation;

        //Delete additional loops
        final_rotation = (final_rotation % 360);

        //Prioritize the lowest angle on a circle
        //Example: Between be 350º and -10º we'll choose -10º
        if (Mathf.Abs(final_rotation) > 180)
        {
            float sign = Mathf.Sign(final_rotation);
            final_rotation = 360 - Mathf.Abs(final_rotation);
            final_rotation *= -sign;
        }

        if (Mathf.Abs(final_rotation) <= min_angle)
        {
            move.SetRotationVelocity(0f);
        }
        else
        {
            move.AccelerateRotation(final_rotation);
        }
    }
}
