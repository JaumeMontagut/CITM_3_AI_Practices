using UnityEngine;
using System.Collections;

public class KinematicWander : MonoBehaviour {

	public float max_angle = 0.5f;
    public float stopTime = 0.5f;
    public float wonderTime = 0.5f;
    //Posar offsets tambe

	Move move;

	// Use this for initialization
	void Start () {
		move = GetComponent<Move>();
	}

	// Update is called once per frame
	void Update () 
	{
        // TODO 9: Generate a velocity vector in a random rotation (use RandomBinominal) and some attenuation factor
        move.SetMovementVelocity(new Vector3(Random.Range(-1f, 1f), 0f, Random.Range(-1f, 1f)).normalized * move.max_mov_velocity);
	}
}
