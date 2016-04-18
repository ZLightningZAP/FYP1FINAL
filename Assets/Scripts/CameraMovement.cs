using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform[] Waypoints;   //Waypoints to move towards
    public Transform[] RotationPoints;  //Angles to rotate towards
    public float[] WaitTimes;   //Waiting Time for each way point

    public float MovementSpeed;    //Movement Speed of Camera
    public float RotationSpeed;     //Rotation Speed of Camera

    public float WaitBeforeShooting; //Waiting time before the enemy shoots the player

    private float WaitTime; //Time to wait before moving to next waypoint
    private float waitTimer;    //Count Timer

    //Position
    private Transform CurrentTransform;  //Current Position of Camera

    private Transform NextTransform; //Next Position to move towards

    //Rotation
    private Transform NextRotation; //Next Rotation to rotate towards

    private int Index;   //Current Index of waypoint
    private float distanceGap;  //Used to check if camera has reached target destination

    //Camera shake
    private bool Shaking = false;

    public bool goingtoshake = false;
    private bool UpdateOriginal = false;
    public float ShakeDuration = 0f;
    public float ShakeAmount = 0.7f;
    public float decreaseFactor = 1.0f;
    private Vector3 OriginalPos;
    private Vector3 OriginalRot;
    private bool Checked = false;
    public static bool Goingtoshoot = false;

    // Use this for initialization
    private void Start()
    {
        CurrentTransform = GameObject.FindGameObjectWithTag("MainCamera").transform;
        NextTransform = CurrentTransform;

        Index = 0;
        distanceGap = 0.01f;

        //Only if there is atleast 1 waypoint
        if (Waypoints.Length > 0)
        {
            NextTransform = Waypoints[Index];
            WaitTime = WaitTimes[Index];
        }
    }

    // Update is called once per frame
    private void Update()
    {
        if (goingtoshake == true)
        {
            Shake();
        }

        if (Shaking == false)
        {
            if (Vector3.Distance(NextTransform.position, CurrentTransform.position) > distanceGap)
            {
                //Go towards the next position
                CurrentTransform.position = Vector3.MoveTowards(CurrentTransform.position, NextTransform.position, MovementSpeed * Time.deltaTime);
                if (Checked == true)
                {
                    Checked = false;
                    EnemyManager.CameraMoved();
                }
                if (Goingtoshoot == true)
                {
                    Goingtoshoot = false;
                }
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
                        WaitTime = WaitTimes[Index - 1];
                        waitTimer = 0.0f;
                        print("Going to next point!");
                    }
                }

                if (Checked == false)
                {
                    //Check how many enemy on the screen when the camera stops moving
                    EnemyManager.NumberOnScreen();
                    if (EnemyManager.CanBeSeen.Count == 0)
                    {
                        return;
                    }
                    Checked = true;
                }

                if (Goingtoshoot == false)
                {
                    EnemyManager.Shooting();
                    Goingtoshoot = true;
                }
            }

            if (RotationPoints.Length > 0)
            {
                if (RotationPoints[Index].position != transform.position)
                {
                    Quaternion rotation = Quaternion.LookRotation(RotationPoints[Index].position - transform.position);
                    CurrentTransform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * RotationSpeed);
                }
            }
        }
    }

    // Camera shake
    private void Shake()
    {
        if (UpdateOriginal == false)
        {
            OriginalPos = CurrentTransform.localPosition;
            UpdateOriginal = true;
        }

        if (ShakeDuration > 0)
        {
            CurrentTransform.localPosition = OriginalPos + Random.insideUnitSphere * ShakeAmount;
            ShakeDuration -= Time.deltaTime * decreaseFactor;
            Shaking = true;
        }
        else
        {
            ShakeDuration = 0f;
            Shaking = false;
            goingtoshake = false;
            UpdateOriginal = false;
        }
    }
}