using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {

    public Transform[] Waypoints;   //Waypoints to move towards
    public Transform[] RotationPoints;  //Angles to rotate towards
    public float[] WaitTimes;   //Waiting Time for each way point

    public float MovementSpeed;    //Movement Speed of Camera
    public float RotationSpeed;     //Rotation Speed of Camera

    private float WaitTime; //Time to wait before moving to next waypoint
    private float waitTimer;    //Count Timer

    //Position
    private Transform CurrentTransform;  //Current Position of Camera
    private Transform NextTransform; //Next Position to move towards

    //Rotation
    private Transform NextRotation; //Next Rotation to rotate towards
    private Vector3 TargetDirection;

    private int Index;   //Current Index of waypoint

	// Use this for initialization
	void Start () {

        CurrentTransform = GameObject.FindGameObjectWithTag("MainCamera").transform;

        Index = 0;

        //Only if there is atleast 1 waypoint
        if(Waypoints.Length > 0)
        {
            NextTransform = Waypoints[Index];
            TargetDirection = RotationPoints[Index].position - CurrentTransform.position;
            WaitTime = WaitTimes[Index];
        }

	}
	
	// Update is called once per frame
	void Update () {
        
        if (Vector3.Distance(NextTransform.position, CurrentTransform.position) > 0.01f)
        {
            //Go towards the next position
            CurrentTransform.position = Vector3.MoveTowards(CurrentTransform.position, NextTransform.position, MovementSpeed * Time.deltaTime);
            print(CurrentTransform.position);
            print(NextTransform.position);
        }
        else
        {
            waitTimer += Time.deltaTime;
            print(waitTimer);
    
            if (waitTimer > WaitTime)
            {
                //Only if its still within bounds of the waypoint
                if (Waypoints.Length > Index + 1)
                {
                    Index++;
                    NextTransform = Waypoints[Index];
                    WaitTime = WaitTimes[Index-1];
                    waitTimer = 0.0f;
                }
            }
        }

        TargetDirection = RotationPoints[Index].position - CurrentTransform.position;
        Vector3 newDirection = Vector3.RotateTowards(CurrentTransform.forward, TargetDirection, RotationSpeed * Time.deltaTime, 0.0f);

        CurrentTransform.rotation = Quaternion.LookRotation(newDirection);
        
	}
}
