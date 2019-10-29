using UnityEngine;
using System.Collections;
using BansheeGz.BGSpline.Components;
using BansheeGz.BGSpline.Curve;

public class SteeringFollowPath : MonoBehaviour {

	Move move;
	SteeringSeek seek;

    public float min_distance = 1.0f;

    public BGCcMath path;

    private int trgPointIdx = 0;
    private float trgPointRation = 0f;

    private float totalPathDist = 0f;

    private float currRation = 0f;
    public float rationSpeed = 0.05f;

	// Use this for initialization
	void Start () {
		move = GetComponent<Move>();
		seek = GetComponent<SteeringSeek>();

        // TODO 1: Calculate the closest point from the tank to the curve

        //float min_dist = float.MaxValue;
        //int closestPoint = 0;
        //for (int i = 0; i < curve.Curve.PointsCount; ++i)
        //{
        //    float newDist = Vector3.Distance(transform.position, curve.Curve[i].PositionWorld);
        //    if (newDist < min_dist)
        //    {
        //        min_dist = newDist;
        //        closestPoint = i;
        //    }
        //}
        //trgPoint = closestPoint;

        totalPathDist = path.GetDistance();//If you don't put anything you get the total distance of the path

        float distance = 0f;
        transform.position = path.CalcPositionByClosestPoint(transform.position, out distance);
        trgPointIdx = path.CalcSectionIndexByDistance(distance);
        currRation = trgPointRation = distance / totalPathDist;
    }

    // Update is called once per frame
    void Update () 
	{
        // TODO 2: Check if the tank is close enough to the desired point
        // If so, create a new point further ahead in the path

        currRation += rationSpeed * Time.deltaTime;
        if (currRation > trgPointRation)
        {
            trgPointIdx++;
            if (trgPointIdx >= path.Curve.PointsCount)
            {
                trgPointIdx = 0;
            }
            trgPointRation = path.GetDistance(trgPointIdx) / totalPathDist;
        }
    }

	void OnDrawGizmosSelected() 
	{

		if(isActiveAndEnabled)
		{
			// Display the explosion radius when selected
			Gizmos.color = Color.green;
			// Useful if you draw a sphere were on the closest point to the path
		}

	}
}
