using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {

    public Transform[] Waypoints;   //Waypoints to move towards
    public Transform[] RotationPoints;  //Angles to rotate towards

    public float MovementSpeed;    //Movement Speed of Camera
    public float RotationSpeed;     //Rotation Speed of Camera

    public float WaitTime;  //Wait Time before moving

    private float waitTimer;    

    //Position
    private Transform CurrentTransform;  //Current Position of Camera
    private Transform NextTransform; //Next Position to move towards

    //Rotation
    private Transform NextRotation; //Next Rotation to rotate towards
    private Vector3 TargetDirection;

    private int Index;   //Current Index of waypoint

    public struct Test
    {
        public int a;

        Test(int b)
        {
            a = 0;
        }
    }

    public Test[] testarray;

	// Use this for initialization
	void Start () {

        CurrentTransform = GameObject.FindGameObjectWithTag("MainCamera").transform;

        Index = 0;

        //Only if there is atleast 1 waypoint
        if(Waypoints.Length > 0)
        {
            NextTransform = Waypoints[Index];
            TargetDirection = RotationPoints[Index].position - CurrentTransform.position;
        }

        testarray = new Test[4];
        testarray.Initialize();
        print(testarray[0].a);
	}
	
	// Update is called once per frame
	void Update () {
        
        if (CurrentTransform.position != NextTransform.position)
        {
            //Go towards the next position
            CurrentTransform.position = Vector3.MoveTowards(CurrentTransform.position, NextTransform.position, MovementSpeed * Time.deltaTime);
        }
        else
        {
            waitTimer += Time.deltaTime;

            if (waitTimer > WaitTime)
            {
                //Only if its still within bounds of the waypoint
                if (Waypoints.Length > Index + 1)
                {
                    Index++;
                    NextTransform = Waypoints[Index];
                }
            }
        }

        TargetDirection = RotationPoints[Index].position - CurrentTransform.position;
        Vector3 newDirection = Vector3.RotateTowards(CurrentTransform.forward, TargetDirection, RotationSpeed * Time.deltaTime, 0.0f);

        CurrentTransform.rotation = Quaternion.LookRotation(newDirection);
        
	}
}
