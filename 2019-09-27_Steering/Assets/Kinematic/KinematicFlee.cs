using UnityEngine;
using System.Collections;

public class KinematicFlee : MonoBehaviour {

	Move move;

	// Use this for initialization
	void Start () {
		move = GetComponent<Move>();
	}
	
	// Update is called once per frame
	void Update () 
	{
        // TODO 6: To create flee just switch the direction to go
        Vector3 direction = transform.position - move.target.transform.position;
        move.SetMovementVelocity(direction.normalized * move.max_mov_velocity);
    }
}
