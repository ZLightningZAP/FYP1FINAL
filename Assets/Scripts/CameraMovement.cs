using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public GameObject WaypointCanvas;
    private List<Waypoint> Waypoint = new List<Waypoint>();
    public List<Waypoint> SortedWaypoint = new List<Waypoint>();

    public float MovementSpeed;    //Movement Speed of Camera
    public float RotationSpeed;     //Rotation Speed of Camera
    private float waitTimer;    //Count Timer

    private Transform CurrentTransform;  //Current Position of Camera
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

    public EnemyManager enemiManager;

    public GameObject Deadpanel;

    // Use this for initialization
    private void Start()
    {
        CurrentTransform = GameObject.FindGameObjectWithTag("MainCamera").transform;

        Index = 0;
        distanceGap = 0.01f;

        foreach (var waypoint in FindObjectsOfType(typeof(Waypoint)) as Waypoint[])
        {
            Waypoint.Add(waypoint);
        }

        SortedWaypoint = WaypointCanvas.GetComponentsInChildren<Waypoint>().ToList();

        //Play the ambient music
        SoundManager.PlayBackgroundMusic(SoundManager.BackgroundMusic.Ambient);
        SoundManager.SetBGMVolume(0.3f);
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
            //If the camera has reached the final waypoint
            if (Camera.main.transform.position == SortedWaypoint[SortedWaypoint.Count - 1].gameObject.transform.position)
            {
                Deadpanel.SetActive(true);
                return;
            }

            if (SortedWaypoint[Index].gameObject.transform.position != transform.position)
            {
                if (SortedWaypoint[Index].Lookpoint != null)
                {
                    Quaternion rotation = Quaternion.LookRotation(SortedWaypoint[Index].Lookpoint.gameObject.transform.position - transform.position);
                    CurrentTransform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * RotationSpeed);
                    //print("rotating");
                }
                else
                {
                    Quaternion rotation = Quaternion.LookRotation(SortedWaypoint[Index].gameObject.transform.position - transform.position);
                    CurrentTransform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * RotationSpeed);
                }
            }

            if (Vector3.Distance(SortedWaypoint[Index].gameObject.transform.position, CurrentTransform.position) > distanceGap)
            {
                //Go towards the next position
                CurrentTransform.position = Vector3.MoveTowards(CurrentTransform.position, SortedWaypoint[Index].gameObject.transform.position, MovementSpeed * Time.deltaTime);
                if (Checked == true)
                {
                    Checked = false;
                    enemiManager.CameraMoved();
                }
                if (Goingtoshoot == true)
                {
                    Goingtoshoot = false;
                }
            }
            else
            {
                waitTimer += Time.deltaTime;

                if (waitTimer > SortedWaypoint[Index].WaitTime)
                {
                    //Only if its still within bounds of the waypoint
                    if (SortedWaypoint.Count > Index + 1)
                    {
                        Index++;
                        waitTimer = 0.0f;
                        print("Going to next point!");
                    }
                }

                if (Checked == false)
                {
                    //Check how many enemy on the screen when the camera stops moving
                    enemiManager.NumberOnScreen();
                    if (enemiManager.CanBeSeen.Count == 0)
                    {
                        return;
                    }
                    Checked = true;
                }

                if (Goingtoshoot == false)
                {
                    enemiManager.Shooting();
                    Goingtoshoot = true;
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